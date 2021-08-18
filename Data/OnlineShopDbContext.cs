namespace ASP.NET_Core_Project_Online_Shop.Data
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
  

    public class OnlineShopDbContext : IdentityDbContext<User>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; }

        public DbSet<TradePartner> TradePartners { get; init; }

        public DbSet<CartItem> ShoppingCartItems { get; init; }

        public DbSet<Order> Orders { get; init; }

        public DbSet<OrderProduct> OrderProducts { get; init; }

        public DbSet<ShippingDetails> ShippingDetails { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder
                .Entity<TradePartner>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<TradePartner>(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<OrderProduct>()
               .HasKey(op => new { op.OrderId, op.ProductId });

            builder
               .Entity<Order>()
               .HasMany(o => o.OrderProducts)
               .WithOne(op => op.Order)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<CartItem>()
                .HasKey(x => new { x.ProductId, x.UserId });

            
            base.OnModelCreating(builder);
        }
    }
}
