namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderProduct
    {
        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product product { get; set; }

        public int Quantity { get; set; }
    }
}
