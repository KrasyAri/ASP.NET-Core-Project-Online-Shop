namespace ASP.NET_Core_Project_Online_Shop.Services.Order
{
    using ASP.NET_Core_Project_Online_Shop.Services.Order.Models;
    using System.Collections.Generic;

    public interface IOrderService
    {
        public int CreateOrderInTheDatabase(string userId);

        public bool FinnishOrder(string userId, int orderId);

        public OrderServiceModel OrderDetailsFromCart(string userId);

       
        public IEnumerable<OrderServiceModel> UsersOrders(string userId);

    }
}
