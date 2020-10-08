using Egras.Business;
using Egras.Business.Interfaces;
using Egras.Entities;
using Egras.LoggerService;
using Egras.Repository;
using Egras.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Threading.Tasks;

namespace EgrasWebAPI.API.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IUserManager, UserManager>();
            //services.AddTransient<IUserManager, IUserManager>();
            //services.AddTransient<IUserRepository, IUserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<Menu>, MenuRepository>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Egras Web API", Version = "v1" });
            });
        }
        public static void ConfigureJWT(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "Egras.raj.nic.in",
                   ValidAudience = "Egras.raj.nic.in",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("R!S@G#A$S%SEC!CUR@ITY#"))
               };
           });
        }
        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(ValidatorActionFilter)); });
        }
    }
}
