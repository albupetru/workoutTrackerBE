using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using workoutTracker.Domain.Extensions;
using workoutTracker.Domain.Helpers;
using workoutTracker.Domain.Models.Configuration;
using workoutTracker.Domain.Repositories.Common;
using workoutTracker.Domain.Services.Implementation;
using workoutTracker.Domain.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserSession, UserSession>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// TODO: consider moving some of the code to separate methods in a class for startupextensions/services configuration
// when this gets too large
var sqlDbSettings = builder.Configuration.GetSection<SQLDatabaseSettings>("SQLDatabaseSettings");
var applicationSecrets = builder.Configuration.GetSection<ApplicationSecrets>("ApplicationSecrets");
var googleSecrets = builder.Configuration.GetSection<GoogleSecrets>("GoogleSecrets");

builder.Services.RegisterSqliteDatabaseContext(sqlDbSettings.ConnectionString);
builder.Services.AddSingleton(applicationSecrets);
builder.Services.AddSingleton(googleSecrets);
builder.Services.AddSingleton<IGoogleLoginService, GoogleLoginService>();

builder.Services.AddHttpContextAccessor();

// Setup CORS.
var allowedOrigins = builder.Configuration.GetSection<string[]>("AllowedOrigins");
const string corsPolicyName = "AllowedOrigins";
builder.Services.AddCors(options => options.AddPolicy(corsPolicyName, policy => policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));

// Setup authentication.
builder.Services
       .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters =
               new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = SecurityKeyHelper.GetKey(applicationSecrets.SecurityKey),
                   RequireSignedTokens = true,
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.FromMinutes(15),
                   RoleClaimType = ClaimTypes.Role // Tell ASP.NET where to find roles
               };
           options.RequireHttpsMetadata = false;
           options.SaveToken = true;
       });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                TokenUrl = new Uri("/swagger/token", UriKind.Relative),
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "OpenID" },
                    { "email", "Email" },
                    { "profile", "Profile" }
                }
            }
        }
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new[] { "openid", "email", "profile" }
        }
    });
});

var app = builder.Build();

// Configure CORS.
app.UseCors(corsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId(googleSecrets.ClientId);
        options.OAuthScopes("openid", "email", "profile");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
