namespace ASP.NET_Core_Project_Online_Shop.Services.Order.Models
{
    using System.Collections.Generic;

    public class OrderServiceModel
    {
        public int OrderId { get; init; }

        public string UserId { get; set; }

        public ICollection<ProductOrderServiceModel> Products { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TradePartnerTotalAmount { get; set; }
    }
}
