namespace ASP.NET_Core_Project_Online_Shop.Services.Cart.Models
{
   
    public class CartViewServiceMode
    {

        public string ProductId { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public string ProductImage { get; init; }

        public string UserId { get; init; }

        public int Quantity { get; set; }

    }
}
