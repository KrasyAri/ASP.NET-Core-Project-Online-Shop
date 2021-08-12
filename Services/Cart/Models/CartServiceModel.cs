namespace ASP.NET_Core_Project_Online_Shop.Services.Cart.Models
{
    using System;

    public class CartServiceModel
    {
        public string CartItemId { get; init; }

        public string UserId { get; init; }

        public int Quantity { get; init; }

        public DateTime DateCreated { get; init; }

        public string ProductId { get; init; }
    }
}
