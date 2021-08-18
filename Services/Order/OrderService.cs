namespace ASP.NET_Core_Project_Online_Shop.Services.Order
{
    using ASP.NET_Core_Project_Online_Shop.Services.Order.Models;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Data;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly OnlineShopDbContext data;

        public OrderService(OnlineShopDbContext data) 
            => this.data = data;


        public int CreateOrderInTheDatabase(string userId)
        {

            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                UserId = userId
            };

            data.Orders.Add(order);
            data.SaveChanges();


            var orderId = order.Id;

            return orderId;
        }

        
        public bool FinnishOrder(string userId, int orderId)
        {
            var productsInCart = data.ShoppingCartItems
                .Where(s => s.UserId == userId)
                .ToList();

            if (productsInCart == null)
            {
                return false;
            }

            foreach (var item in productsInCart)
            {
                var productId = item.ProductId;
                var quantity = item.Quantity;

                data.OrderProducts.Add(new OrderProduct
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                });

                data.ShoppingCartItems.Remove(item);
                data.SaveChanges();
            }

            return true;
        }

        public OrderServiceModel OrderDetailsFromCart(string userId)
        {
            var newOrderItems = data.ShoppingCartItems
                .Where(sh => sh.UserId == userId)
                .Include(i => i.Product)
                .ToList();

            if (newOrderItems == null)
            {
                return null;
            }

            var newOrder = new OrderServiceModel()
            {
                Products = new List<ProductOrderServiceModel>()
            };

            foreach (var item in newOrderItems)
            {
                var newItem = new ProductOrderServiceModel
                {
                    ProductName = item.Product.Name,
                    Price = item.Product.Price,
                    //new
                    TradePartnerPrice = item.Product.TradePartnerPrice,
                    Quantity = item.Quantity,
                };

                newItem.TotalPrice = newItem.Price * newItem.Quantity;
                newItem.TradePartnerTotalPrice = newItem.TradePartnerPrice * newItem.Quantity;

                newOrder.Products.Add(newItem);
            }

            newOrder.TradePartnerTotalAmount = newOrder.Products.Sum(p => p.TradePartnerTotalPrice);
            newOrder.TotalAmount = newOrder.Products.Sum(p => p.TotalPrice);
            newOrder.Products = newOrder.Products.OrderBy(p => p.ProductName).ToList();

            return newOrder;
        }

        public IEnumerable<OrderServiceModel> UsersOrders(string userId)
        {
            var ordersProducts = data.OrderProducts
               .Where(o => o.Order.UserId == userId)
               .Include(o => o.Product)
               .AsQueryable();

            if (ordersProducts == null)
            {
                return null;
            }

            var ordersId = ordersProducts
                 .Select(o => o.OrderId)
                 .Distinct()
                 .ToList();

            var orders = new List<OrderServiceModel>();

            foreach (var id in ordersId)
            {
                var order = new OrderServiceModel
                {
                    OrderId = id,
                    Products = new List<ProductOrderServiceModel>()
                };

                foreach (var item in ordersProducts)
                {
                    if (item.OrderId == id)
                    {
                        var product = new ProductOrderServiceModel
                        {
                            ProductName = item.Product.Name,
                            Price = item.Product.Price,
                            TradePartnerPrice = item.Product.TradePartnerPrice,
                            Quantity = item.Quantity,
                            TotalPrice = item.Product.Price * item.Quantity,
                            TradePartnerTotalPrice = item.Product.TradePartnerPrice * item.Quantity
                        };

                        order.Products.Add(product);
                    }
                }

                order.TradePartnerTotalAmount = order.Products.Sum(p => p.TradePartnerTotalPrice);
                order.TotalAmount = order.Products.Sum(p => p.TotalPrice);

                orders.Add(order);
            }

            return orders;
        }
    }
}
