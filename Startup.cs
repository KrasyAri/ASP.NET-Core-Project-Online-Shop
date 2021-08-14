namespace ASP.NET_Core_Project_Online_Shop
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.TradePartners;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Services.Cart;

    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<OnlineShopDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITradePartnerService, TradePartnerService>();
            services.AddTransient<ICartService, CartService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    "areaRoute",
                //    "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultAreaRoute();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
