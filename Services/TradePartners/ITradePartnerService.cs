namespace ASP.NET_Core_Project_Online_Shop.Services.TradePartners
{
    public interface ITradePartnerService
    {
        public bool IsTradePartner(string userId);

        public int IdByUser(string userId);
    }
}
