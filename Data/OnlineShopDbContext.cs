namespace ASP.NET_Core_Project_Online_Shop.Data
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
  

    public class OnlineShopDbContext : IdentityDbContext
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
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Product>()
                .HasOne(c => c.ProductType)
                .WithMany(d => d.Products)
                .HasForeignKey(c => c.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Product>()
               .HasOne(c => c.Series)
               .WithMany(d => d.Products)
               .HasForeignKey(c => c.SeriesId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TradePartner>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<TradePartner>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
