namespace ASP.NET_Core_Project_Online_Shop.Services.TradePartners
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using System.Linq;

    public class TradePartnerService : ITradePartnerService
    {
        private readonly OnlineShopDbContext data;

        public TradePartnerService(OnlineShopDbContext data) 
            => this.data = data;

        public int IdByUser(string userId)
              => this.data
                  .TradePartners
                  .Where(p => p.UserId == userId)
                  .Select(p => p.Id)
                  .FirstOrDefault();

        public bool IsTradePartner(string userId)
             => this.data
                .TradePartners
                .Any(d => d.UserId == userId);
    }
}
