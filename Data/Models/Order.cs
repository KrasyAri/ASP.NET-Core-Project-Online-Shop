namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Order
    {
        public Order()
        {
            this.OrderProducts = new List<OrderProduct>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ShippingDetailsId { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }

        

    }
}
