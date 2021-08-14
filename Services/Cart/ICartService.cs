namespace ASP.NET_Core_Project_Online_Shop.Services.Cart
{
    using ASP.NET_Core_Project_Online_Shop.Services.Cart.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICartService
    {
        public bool AddToCart(int productId, string userId);

        public bool Add(int productId, string userId);

        public bool Remove(int productId, string userId);

        public bool Delete(int productId, string userId);

        public IEnumerable<CartViewServiceMode> UsersCart(string userId);
    }
}
