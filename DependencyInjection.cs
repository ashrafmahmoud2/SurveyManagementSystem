using Asp.Versioning.ApiExplorer;
using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using SurveyBasket.Health;
using SurveyBasket.OpenApiTransformers;
using SurveyBasket.Settings;
using System.Reflection;
using System.Text;
using System.Threading.RateLimiting;

namespace SurveyBasket;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.

        Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        Services.AddOpenApi();


        services.AddAuthConfig(configuration);

        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services
            //.AddSwaggerServices()
            .AddMapsterConfig()
            .AddFluentValidationConfig();

        services.AddScoped<IAuthService, AuthService>();
       

      
        return services;
    }

 

  
}