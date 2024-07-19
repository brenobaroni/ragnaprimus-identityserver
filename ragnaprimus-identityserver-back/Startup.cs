using Data.Context;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using ragnaprimus_identityserver_back.CustomRequestValitador;
using ragnaprimus_identityserver_back.Extensions;
using Serilog;

namespace ragnaprimus_identityserver_back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //Mysql Context
            services.AddDbContext<RagnarokContext>(opt =>
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 33));
                opt.UseMySql(Configuration.GetConnectionString("MySql"), serverVersion);
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            });

            services.AddDependencies();

            services.AddIdentityServer(setupAction: options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            }).AddConfigurationStore(options =>
            {
                options.DefaultSchema = "identityserver";
                options.ConfigureDbContext = b =>
                {
                    var serverVersion = new MySqlServerVersion(new Version(8, 33));
                    b.UseMySql(Configuration.GetConnectionString("MySqlIdentity"), serverVersion, b =>
                    {
                        b.MigrationsAssembly("ragnaprimus-identityserver-back");
                        b.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    });

                };
                
            })
            .AddOperationalStore(options =>
            {
                options.DefaultSchema = "identityserver";
                options.ConfigureDbContext = b =>
                {
                    var serverVersion = new MySqlServerVersion(new Version(8, 33));
                    b.UseMySql(Configuration.GetConnectionString("MySqlIdentity"), serverVersion, b => { b.MigrationsAssembly("ragnaprimus-identityserver-back"); b.SchemaBehavior(MySqlSchemaBehavior.Ignore); });

                };
                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 3600; // interval in seconds (default is 3600)
            })
            .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            .AddProfileService<CustomProfileService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("NormalUser", policy => { policy.RequireAuthenticatedUser(); policy.RequireClaim("role", "user"); });
                options.AddPolicy("Admin", policy => { policy.RequireAuthenticatedUser(); policy.RequireClaim("role", "admin"); });
            });

            IdentityModelEventSource.ShowPII = true; //Add this line

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.Use(async (ctx, next) =>
            {
                var serverUrls = ctx.RequestServices.GetRequiredService<IServerUrls>();
                serverUrls.Origin = serverUrls.Origin = Configuration.GetSection("Parameters").GetSection("IdentityUrl").Value;
                await next();
            });

            app.UseIdentityServer();
            var args = System.Environment.GetCommandLineArgs();
            if (args.Contains("/seed"))
            {
                Log.Information("Seeding database...");
                SeedData.EnsureSeedData(app);
                Log.Information("Done seeding database. Exiting.");
                return;
            }


            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();
            app.UseForwardedHeaders(forwardOptions);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
