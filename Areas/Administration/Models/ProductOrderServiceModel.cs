namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductOrderServiceModel
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal TradePartnerPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal TradePartnerTotalPrice { get; set; }
    }
}
