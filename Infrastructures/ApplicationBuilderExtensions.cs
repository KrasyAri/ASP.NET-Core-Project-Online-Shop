namespace ASP.NET_Core_Project_Online_Shop.Infrastructures
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ASP.NET_Core_Project_Online_Shop.Areas.Admin.AdminConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedSeries(services);
            SeedProductTypes(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Creme" },
                new Category { Name = "Mask" },
                new Category { Name = "Eye Care" },
                new Category { Name = "Peeling" },
                new Category { Name = "Cleaning Products" },
                new Category { Name = "Luxury" },
                new Category { Name = "Others" },
            });

            data.SaveChanges();
        }

        private static void SeedProductTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();

            if (data.ProductTypes.Any())
            {
                return;
            }

            data.ProductTypes.AddRange(new[]
            {
                new ProductType { Name = "Retail" },
                new ProductType { Name = "Professional" },
               
            });

            data.SaveChanges();
        }

        private static void SeedSeries(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();

            if (data.Series.Any())
            {
                return;
            }

            data.Series.AddRange(new[]
            {
                new Series { Name = "Perfect Age Formula" },
                new Series { Name = "Anti-Age Cell Formula" },
                new Series { Name = "Caviar&Radiance" },
                new Series { Name = "Oxigen Formula" },
                new Series { Name = "Global Anti-Age Formula" },
                new Series { Name = "Age Performance Formula" },

            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@biodroga.com";
                    const string adminPassword = "lkjpoi0009";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FirstName = "Admin",
                        LastName = "Arizanova"
                        
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
