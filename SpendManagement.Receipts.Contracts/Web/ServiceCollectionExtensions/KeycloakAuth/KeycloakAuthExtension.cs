using Contracts.Web.Services.Auth;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Contracts.Web.ServiceCollectionExtensions.KeycloakAuth
{
    public static class KeycloakAuthExtension
    {
        public static IServiceCollection AddKeyCloakAuth(this IServiceCollection services, AuthSettings authSettings)
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
                                    var tokenJwt = context.Request.Headers.Authorization.FirstOrDefault();

                                    if (string.IsNullOrEmpty(tokenJwt))
                                    {
                                        context.Response.StatusCode = 401;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsJsonAsync("Invalid JWT token provided! Please check. ");
                                        return;
                                    }

                                    var bearerToken = tokenJwt.Replace("Bearer ", "");
                                    var tokenInfos = tokenHandler.ReadJwtToken(tokenJwt.Replace("Bearer ", ""));
                                    var tenantNumber = tokenInfos.Claims.FirstOrDefault(c => c.Type == "tenant")?.Value;
                                    var tenantRealm = authSettings.Realms.FirstOrDefault(realm => realm.Name == tenantNumber);

                                    if (tenantRealm is null)
                                    {
                                        context.Response.StatusCode = 401;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsJsonAsync("This token don't belongs to valid tenant. Please check!");
                                        return;
                                    }

                                    var audience = tokenInfos.Claims.FirstOrDefault(c => c.Type == "aud")?.Value;
                                    if (string.IsNullOrEmpty(audience))
                                    {
                                        context.Response.StatusCode = 403;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsJsonAsync("Invalid scope provided! Please, check the scopes provided!");
                                        return;
                                    }

                                    var jwksUrl = $"{tenantRealm.Issuer}/protocol/openid-connect/certs";

                                    var jwks = await httpClient.GetStringAsync(jwksUrl);
                                    var jsonWebKeySet = new JsonWebKeySet(jwks);

                                    var tokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidIssuer = tenantRealm.Issuer,
                                        ValidateAudience = true,
                                        ValidAudience = tenantRealm.Audience,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        IssuerSigningKeys = jsonWebKeySet.Keys
                                    };

                                    var claims = tokenHandler.ValidateToken(bearerToken, tokenValidationParameters, out var validatedToken);
                                    context.Principal = claims;
                                    context.Success();
                                }
                                catch (Exception e)
                                {
                                    context.Response.StatusCode = 500;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsJsonAsync("The following error occurs during the authentication process: " + e.Message);
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

            services.AddSingleton<JwtSecurityTokenHandler>()
                    .AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
