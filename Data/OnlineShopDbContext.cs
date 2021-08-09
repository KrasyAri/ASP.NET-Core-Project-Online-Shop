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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
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
