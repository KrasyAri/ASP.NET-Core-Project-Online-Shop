namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Models
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrdersShippingDetailsServiceModel
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserFirstName { get; set; }

        public string LastName { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

    }
}
