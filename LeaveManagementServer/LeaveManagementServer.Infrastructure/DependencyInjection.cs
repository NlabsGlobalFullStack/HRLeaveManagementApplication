﻿using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Infrastructure.BackgroundServices;
using LeaveManagementServer.Infrastructure.Context;
using LeaveManagementServer.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Nlabs.GenericRepository;
using Scrutor;
using System.Reflection;

namespace LeaveManagementServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services
            .AddIdentity<AppUser, IdentityRole<Guid>>(cfr =>
            {
                cfr.Password.RequiredLength = 1;
                cfr.Password.RequireNonAlphanumeric = false;
                cfr.Password.RequireUppercase = false;
                cfr.Password.RequireLowercase = false;
                cfr.Password.RequireDigit = false;
                cfr.SignIn.RequireConfirmedEmail = true;
                cfr.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                cfr.Lockout.MaxFailedAccessAttempts = 3;
                cfr.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtTokenOptionsSetup>();
        services.AddAuthentication()
            .AddJwtBearer();
        services.AddAuthorizationBuilder();

        services.Scan(action =>
        {
            action
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

        services.AddHealthChecks()
            .AddCheck("health-check", () => HealthCheckResult.Healthy())
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddHttpClient();

        services.AddHostedService<HealthCheckBackgroundService>();

        return services;
    }
}