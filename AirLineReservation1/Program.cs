using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AirLineReservation1.Models;

namespace AirLineReservation1
{
    public class Program
    {
        public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminExists = roleManager.RoleExistsAsync("Admin")
                        .GetAwaiter()
                        .GetResult();

            if (!adminExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin"))
                            .GetAwaiter()
                            .GetResult();
            }

            var userExists = roleManager.RoleExistsAsync("User")
                        .GetAwaiter()
                        .GetResult();

            if (!userExists)
            {
                roleManager.CreateAsync(new IdentityRole("User"))
                            .GetAwaiter()
                            .GetResult();
            }

        }

        public static void InitializeAdminUsers(UserManager<User> userManager)
        {
            var adminUser = userManager.FindByEmailAsync("admin@gmail.com")
                                        .GetAwaiter()
                                        .GetResult();

            User admin = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            userManager.CreateAsync(admin, "Daniel123@").Wait();
            if (adminUser != null)
            {
                var result = userManager.AddToRoleAsync(adminUser, "Admin")
                            .GetAwaiter()
                            .GetResult();
        }


    }
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<User>>();
                InitializeRoles(roleManager);
                InitializeAdminUsers(userManager);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
