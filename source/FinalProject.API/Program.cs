using FinalProject.Application.Usecase;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using FinalProject.SharedKernel.Domain.Settings;
using Identity.Module.Auth;
using IdentityModule.Auth;
using IdentityModule.Queries;
using Infrastructure.Identity;
using Infrastructure.Middleware;
using System.Reflection;
using FluentValidation;
using User.Module.Services;
using Job.Module.Service;
using Serilog;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddLogging();
builder.Services.AddHttpContextAccessor();

#region Service Registry
Assembly.Load("Identity.Module");
Assembly.Load("User.Module");
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
#region User/Authorization
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueries, UserQueries>();
builder.Services.AddScoped<IClaimsManager, ClaimsManager>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
#endregion
builder.Services.AddTransient<GlobalExceptionHandler>();

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddAutoMapper(assembly);
    builder.Services.AddValidatorsFromAssembly(assembly);
}
#endregion

#region SeriLog
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console()
    .WriteTo.File("logs/Log-.txt",rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();
#endregion

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token} \")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("JWTSettings:Key").Value)),
    };
});
#endregion
#region Configurations
ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));
#endregion

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
