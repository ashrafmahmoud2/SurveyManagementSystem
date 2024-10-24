﻿using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SurveyManagementSystem.Api.Authentication;
using SurveyManagementSystem.Api.Authentication.OptionsPattern;
using SurveyManagementSystem.Api.Contracts.Email;


namespace SurveyManagementSystem;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

#pragma warning disable // Suppressing all warnings temporarily
        services.AddHybridCache();
#pragma warning restore // Re-enabling warnings



        
        //services.AddHybridCache();

        services.AddCors(options =>
          options.AddDefaultPolicy(builder =>
              builder
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>()!)//AllowedOrigins is array in appsettings
          )
      );

        // Register IHttpContextAccessor
        services.AddHttpContextAccessor();

        services.AddAuthConfig(configuration);

        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services
            //.AddSwaggerServices()
            .AddMapsterConfig()
            .AddFluentValidationConfig();

        services.AddScoped<IPollService, PollService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IQuestionServices, QuestionServices>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();


        // Configure Email Service
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));


        return services;
    }

    private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingConfig));

        return services;
    }

    private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    private static IServiceCollection AddAuthConfig(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

        //services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        //services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        services.AddSingleton<IJwtProvider, JwtProvider>();

        services.AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.Key!)),
                ValidIssuer = jwtSettings?.Issuer,
                ValidAudience = jwtSettings?.Audience
            };
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.SignIn.RequireConfirmedEmail = true;
            options.User.RequireUniqueEmail = true;


        });

        return services;
    }

}