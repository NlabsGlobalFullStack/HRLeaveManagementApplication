﻿using LeaveManagementServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagementServer.WebAPI.Middlewares;
public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Cuma",
                    LastName = "Köse",
                    DateOfBirth = new DateOnly(1900, 11, 31),
                    EmailConfirmed = true
                };

                userManager.CreateAsync(user, "1").Wait();
            }
        }
    }
}