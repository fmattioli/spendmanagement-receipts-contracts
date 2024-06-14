namespace Contracts.Web.ServiceCollectionExtensions.KeycloakAuth
{
    public class AuthSettings
    {
        public IEnumerable<Realm> Realms { get; set; } = [];
        public string? ClientId { get; set; }
        public string? Resource { get; set; }
        public string? AuthServerUrl { get; set; }
        public string? PolicyName { get; set; }
        public IEnumerable<string>? Roles { get; set; }
        public IEnumerable<string>? Scopes { get; set; }
    }

    public class Realm
    {
        public string? Name { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
    }
}
