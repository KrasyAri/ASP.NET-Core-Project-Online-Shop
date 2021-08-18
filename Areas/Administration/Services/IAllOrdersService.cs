namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Services
{
    using ASP.NET_Core_Project_Online_Shop.Areas.Administration.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAllOrdersService
    {
        public IEnumerable<OrderServiceModel> AllOrders();

    }
}
