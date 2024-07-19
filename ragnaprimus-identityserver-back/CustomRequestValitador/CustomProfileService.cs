using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Service.Contracts;
using System.Security.Claims;

namespace ragnaprimus_identityserver_back.CustomRequestValitador
{
    public class CustomProfileService : IProfileService
    {
        private readonly ILoginService _loginService;

        public CustomProfileService(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _loginService.GetUserAsync(context.Subject.GetSubjectId());

            var claimsFromData = user.claims.Split(",");
            var claims = new List<Claim>();

            foreach ( var item in claimsFromData)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.ToString()));
            }

            claims.AddRange(new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Name, user.nome),
                new Claim(ClaimTypes.PrimarySid, user.id.ToString())
            });
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            
        }
    }
}
