namespace ASP.NET_Core_Project_Online_Shop.Services.Cart
{
    using ASP.NET_Core_Project_Online_Shop.Services.Cart.Models;
    using System.Collections.Generic;

    public interface ICartService
    {
        public bool AddToCart(int productId, string userId);

        public bool AddQuantity(int productId, string userId);

        public bool RemoveQuantity(int productId, string userId);

        public bool Delete(int productId, string userId);

        public IEnumerable<CartViewServiceMode> UsersCart(string userId);
    }
}
