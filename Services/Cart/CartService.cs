namespace ASP.NET_Core_Project_Online_Shop.Services.Cart
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Cart.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {

        private readonly OnlineShopDbContext data;
        private readonly IConfigurationProvider mapper;

        public CartService(
            OnlineShopDbContext data, 
            IConfigurationProvider mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public bool Add(int productId, string userId)
        {
            var user = GetUser(userId);

            if (user == null)
            {
                return false;
            }

            var product = GetProduct(productId);

            if (product == null)
            {
                return false;
            }

            if (data.ShoppingCartItems.Any(c => c.ProductId == productId && c.UserId == userId))
            {
                var cartItem = GetCartItem(productId, userId);

                cartItem.Quantity++;

                data.SaveChanges();
            }
            else
            {
                var cartItem = new CartItem()
                {
                    UserId = userId,
                    Quantity = 1,
                    ProductId = productId
                };

                data.ShoppingCartItems.Add(cartItem);
                data.SaveChanges();
            }

            return true;

        }

        public bool AddToCart(int productId, string userId)
        {
            var cartItem = this.GetCartItem(productId, userId);

            if (cartItem == null)
            {
                return false;
            }

            cartItem.Quantity++;
            data.SaveChanges();

            return true;
        }

        public bool Delete(int productId, string userId)
        {
            var cartItem = this.GetCartItem(productId, userId);

            if (cartItem == null)
            {
                return false;
            }

            data.ShoppingCartItems.Remove(cartItem);
            data.SaveChanges();

            return true;
        }

        public bool Remove(int productId, string userId)
        {
            var cartItem = this.GetCartItem(productId, userId);

            if (cartItem == null)
            {
                return false;
            }

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                data.SaveChanges();
            }

            return true;
        }


        public IEnumerable<CartViewServiceMode> UsersCart(string userId) => data.ShoppingCartItems
            .Where(citem => citem.UserId == userId)
            .ProjectTo<CartViewServiceMode>(this.mapper)
            .ToList();


        private Product GetProduct(int productId) 
            => data.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();

        private User GetUser(string userId)
             => data.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

        private CartItem GetCartItem(int productId, string userId) 
            => data.ShoppingCartItems
               .Where(p => p.ProductId == productId && p.UserId == userId)
               .FirstOrDefault();

    }
}
