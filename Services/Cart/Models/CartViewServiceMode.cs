namespace ASP.NET_Core_Project_Online_Shop.Services.Cart.Models
{
    public class CartViewServiceMode
    {
        public int ProductId { get; init; }

        public string ProductProductCode { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public decimal ProductTradePartnerPrice { get; init; }

        public string ProductImageUrl { get; init; }

        public int Quantity { get; set; }

    }
}
