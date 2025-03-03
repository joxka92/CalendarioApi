using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;

namespace Api_Appointments
{
    public static class Startup
    {
        public static void Start(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder, builder.Configuration);
            var app = builder.Build();
            LoadConfiguration(app);
        }


        private static void ConfigureServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });

            //more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(builder.Configuration["UrlPolicy"])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders()
                    .SetIsOriginAllowed(_ => true);
                });
            });


            //app services
            builder.Services.RegisterInfrastructureServices(configuration);
            builder.Services.RegisterApplicationServices();
            builder.Logging.AddCustomLoggerProvider(Path.Combine(builder.Environment.ContentRootPath, "Log"));
        }

        private static void LoadConfiguration(WebApplication app)
        {

            //Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
               app.UseSwagger();
                app.UseSwaggerUI();
           // }


            app.UseStatusCodePages();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
