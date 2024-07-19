using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using IdentityModel;
using Service.Contracts;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ragnaprimus_identityserver_back.CustomRequestValitador
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILoginService _loginService;

        public ResourceOwnerPasswordValidator(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var resultValidadePassword = await _loginService.ValidadePassword(context.UserName, context.Password);

            if (resultValidadePassword.Item1 && resultValidadePassword.Item2.HasValue)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, context.UserName),
                    new Claim(ClaimTypes.PrimarySid, resultValidadePassword.Item2.Value.ToString())
                };

                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: "custom",
                    claims: claims
                    );

                return;
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient);
            }

        }
    }
}
