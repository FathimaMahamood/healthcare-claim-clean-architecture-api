using HealthcareClaim.API.Middleware;
using HealthcareClaim.Application.Features.Patients.Commands.CreatePatient;
using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Infrastructure;
using HealthcareClaim.Infrastructure.Identity;
using HealthcareClaim.Infrastructure.Options;
using HealthcareClaim.Infrastructure.Persistence;
using HealthcareClaim.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//injected dbcontext from infrastructure project
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<FileStorageOptions>(options =>
{
    // Use wwwroot/uploads folder
    options.UploadPath = Path.Combine(builder.Environment.WebRootPath, "uploads");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
})
    .AddJwtBearer("Bearer", options =>
    {
        var key = Encoding.UTF8.GetBytes(
            builder.Configuration["JwtSettings:JwtSecret"]!);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<JwtService>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(CreatePatientCommand).Assembly));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Provider", "InsuranceAdmin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
app.UseStaticFiles();

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
