namespace ASP.NET_Core_Project_Online_Shop.Data
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
  

    public class OnlineShopDbContext : IdentityDbContext<User>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Series> Series { get; init; }

        public DbSet<ProductType> ProductTypes { get; init; }

        public DbSet<TradePartner> TradePartners { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Product>()
               .HasOne(p => p.Series)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.SeriesId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TradePartner>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<TradePartner>(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
