using Contracts.Web.Services.Auth;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Contracts.Web.ServiceCollectionExtensions.KeycloakAuth
{
    public static class KeycloakAuthExtension
    {
        public static IServiceCollection AddKeycloakAuthentication(this IServiceCollection services, AuthSettings authSettings)
        {
            var httpClient = new HttpClient();
            var tokenHandler = new JwtSecurityTokenHandler();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddKeycloakWebApi(
                    options =>
                    {
                        options.Resource = authSettings.Resource!;
                        options.AuthServerUrl = authSettings.AuthServerUrl;
                        options.VerifyTokenAudience = true;
                    },
                    options =>
                    {
                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = async context =>
                            {
                                try
                                {
                                    var bearerToken = context.Request.Headers.Authorization.FirstOrDefault()!.Replace("Bearer ", "");
                                    var tokenInfos = tokenHandler.ReadJwtToken(bearerToken);
                                    var tenantClaim = tokenInfos.Claims.FirstOrDefault(c => c.Type == "tenant")?.Value;

                                    var realmConfig = authSettings.Realms.FirstOrDefault(realm => realm.Name == tenantClaim);
                                    if (realmConfig is null)
                                    {
                                        context.NoResult();
                                        return;
                                    }

                                    var jwksUrl = $"{realmConfig.Issuer}/protocol/openid-connect/certs";

                                    var jwks = await httpClient.GetStringAsync(jwksUrl);
                                    var jsonWebKeySet = new JsonWebKeySet(jwks);

                                    var tokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidIssuer = realmConfig.Issuer,
                                        ValidateAudience = true,
                                        ValidAudience = realmConfig.Audience,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        IssuerSigningKeys = jsonWebKeySet.Keys
                                    };

                                    var claims = tokenHandler.ValidateToken(bearerToken, tokenValidationParameters, out var validatedToken);
                                    context.Principal = claims;
                                    context.Success();
                                }
                                catch (Exception)
                                {
                                    context.Fail("Token validation failed");
                                }
                            }
                        };
                    }
                );

            services
                .AddAuthorization()
                .AddKeycloakAuthorization()
                .AddAuthorizationBuilder()
                .AddPolicy(
                    authSettings.PolicyName!,
                    policy =>
                    {
                        policy.RequireResourceRolesForClient(
                            authSettings!.Resource!,
                            authSettings!.Roles!.ToArray());
                    }
                );

            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
