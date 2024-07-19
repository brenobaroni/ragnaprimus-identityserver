using Duende.IdentityServer.Models;
using IdentityModel;
using System.Security.Claims;

namespace ragnaprimus_identityserver_back
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = { ClaimTypes.Role },
                },
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api-painel", "API Painel"),
                new ApiScope("api-inter", "API Painel"),
            };


        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
            {
                new ApiResource("api-painel", "API Painel")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {  new Secret("340bff7dd39632e164fdde58d1901dbf97b5a19b34ac735282f778dc29b30a7a".Sha256()) },
                    AllowOfflineAccess = true,
                    RedirectUris = { "https://localhost:5443/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5443/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5443/signout-callback-oidc" },
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Absolute, // Define a expiração absoluta do refresh token
                    AbsoluteRefreshTokenLifetime = 3600,
                    AllowedScopes = { "openid", "profile", "api-painel", "offline_access", "role" },
                },
                new Client
                {
                    ClientId = "m2m.client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets = { new Secret("b311560476-d9e604727127f-4071d57eee84071d5-7eee8a1".Sha256())},

                    // scopes that client has access to
                    AllowedScopes = { "api-inter" }
                },
                new Client
                {
                    ClientId = "google",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.Code,

                    // secret for authentication
                    ClientSecrets = { new Secret("b311560476-d9e604727127f-4071d57eee84071d5-7eee8a1".Sha256())},

                    // scopes that client has access to
                    AllowedScopes = { "openid", "profile", "api-painel", "offline_access", "role" }
                }
            };
    }

}
