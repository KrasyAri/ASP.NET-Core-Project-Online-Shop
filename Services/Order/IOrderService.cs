namespace ASP.NET_Core_Project_Online_Shop.Services.Order
{
    using ASP.NET_Core_Project_Online_Shop.Services.Order.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        public int CreateOrderInTheDatabase(string userId);

        public bool FinnishOrder(string userId, int orderId);

        public OrderServiceModel OrderDetailsFromCart(string userId);

       
        public IEnumerable<OrderServiceModel> UsersOrders(string userId);

        public bool OrderExists(int orderId, string userId);
    }
}
