using FluentValidation.AspNetCore;
using Hangfire;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SurveyManagementSystem.Api.Authentication;
using SurveyManagementSystem.Api.Authentication.Filters;
using SurveyManagementSystem.Api.Authentication.OptionsPattern;
using SurveyManagementSystem.Api.HealthChecks;
using SurveyManagementSystem.Api.Settings;


namespace SurveyManagementSystem;

public static class DependencyInjection
{

    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddControllers();
        services.AddOpenApi();

        // Suppressing warnings temporarily
#pragma warning disable
        services.AddHybridCache();
#pragma warning restore

        services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>()!))
        );

        // Register IHttpContextAccessor
        services.AddHttpContextAccessor();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services
            .AddMapsterConfig()
            .AddFluentValidationConfig();

        services.AddAuthConfig(configuration);
        services.AddBackgroundJobsConfig(configuration);

        // Register scoped services
        services.AddScoped<IPollService, PollService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IQuestionServices, QuestionServices>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ITelegramBotService, TelegramBotService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        // Configure Email Service
        services.AddOptions<EmailSettings>()
            .Bind(configuration.GetSection("Mailjet"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Configure Telegram Service
        services.Configure<TelegramBotSettings>(configuration.GetSection("TelegramBot"));

        //Health Checks
        services.AddHealthChecks()
        .AddSqlServer(name: "database", connectionString: connectionString!)
        .AddHangfire(options => { options.MinimumAvailableServers = 1; })
        .AddCheck<MailProviderHealthCheck>(name: "mail service");

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

    private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

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

    private static IServiceCollection AddBackgroundJobsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));

        services.AddHangfireServer();

        return services;
    }
}
