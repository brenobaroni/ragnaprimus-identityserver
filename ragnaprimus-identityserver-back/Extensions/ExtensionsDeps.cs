using Data.Repository;
using Domain.Contracts_Repository;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using ragnaprimus_identityserver_back.CustomRequestValitador;
using Service.Contracts;
using Service.Services;

namespace ragnaprimus_identityserver_back.Extensions
{
    public static class ExtensionsDeps
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            //Identity
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, CustomProfileService>();

            //Service
            services.AddScoped<ILoginService, LoginService>();

            //Repository
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IZzPainelUserRepository, ZzPainelUserRepository>(); 

            return services;
        }
    }
}
