namespace ASP.NET_Core_Project_Online_Shop.Services.Cart.Models
{
    public class CartViewServiceMode
    {
        public int Id { get; init; }

        public string ProductCode { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public decimal TradePartnerPrice { get; init; }

        public string ImageUrl { get; init; }

        //public string UserId { get; init; }

        public int Quantity { get; set; }

    }
}
