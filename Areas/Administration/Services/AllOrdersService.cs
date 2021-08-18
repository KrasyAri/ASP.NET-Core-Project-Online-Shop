namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Services
{
    using ASP.NET_Core_Project_Online_Shop.Areas.Administration.Models;
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.TradePartners;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AllOrdersService : IAllOrdersService
    {
        private readonly OnlineShopDbContext data;

        public AllOrdersService(OnlineShopDbContext data) 
            => this.data = data;

        public IEnumerable<OrderServiceModel> AllOrders()
        {
            var ordersProducts = data.OrderProducts
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

            var allOrders = new List<OrderServiceModel>();

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

                allOrders.Add(order);
            }

            var tradePartnersOrders = new List<OrderServiceModel>();

            var tradePartnersIds = data.TradePartners.Select(tp => tp.UserId);



            return allOrders;
        }

    }
}
