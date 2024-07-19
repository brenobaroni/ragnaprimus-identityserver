//using Microsoft.IdentityModel.Tokens;
//using ragnaprimus_identityserver_back;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddAuthentication("Bearer")
//            .AddJwtBearer("Bearer", options =>
//            {
//                options.Authority = "https://localhost:7280";
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateAudience = false
//                };
//            });

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


////Identity
//builder.Services.AddIdentityServer()
//    .AddInMemoryApiScopes(Config.ApiScopes)
//    .AddInMemoryClients(Config.Clients);


//var app = builder.Build();

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseIdentityServer();
//app.UseHttpsRedirection();
//app.Run();

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ragnaprimus_identityserver_back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
