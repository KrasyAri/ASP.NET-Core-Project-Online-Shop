namespace ASP.NET_Core_Project_Online_Shop.Services.Order.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderServiceModel
    {
        public int OrderId { get; init; }

        public ICollection<ProductOrderServiceModel> Products { get; set; }

        //public decimal ProductsAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TradePartnerTotalAmount { get; set; }
    }
}
