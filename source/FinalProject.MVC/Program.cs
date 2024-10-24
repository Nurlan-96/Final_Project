using Company.Module.Services;
using EmailModule.Manager;
using FinalProject.Application.Usecase;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using FinalProject.SharedKernel.Domain.Settings;
using Identity.Module.Auth;
using IdentityModule.Auth;
using IdentityModule.Queries;
using Infrastructure.Identity;
using Job.Module;
using Job.Module.Queries;
using Job.Module.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using User.Module.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
#region Service Registration
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#region User/Authorization
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueries, UserQueries>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClaimsManager, ClaimsManager>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
#endregion
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IJobQuery, JobQuery>();
builder.Services.AddScoped<ICVQuery, CVQuery>();
builder.Services.AddScoped<ICVJobQuery, CVJobQuery>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ICVService, CVService>();
builder.Services.AddScoped<ICVJobService, CVJobService>();
builder.Services.AddScoped<ICVRepository, CVRepository>();
builder.Services.AddScoped<ICVJobRepository, CVJobRepository>();
builder.Services.AddScoped<IEmailManager, EmailManager>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddAutoMapper(assembly);
    //builder.Services.AddValidatorsFromAssembly(assembly);
}
#endregion
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Area route
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=Dash}/{action=Index}/{id?}"
    );

    // Default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
