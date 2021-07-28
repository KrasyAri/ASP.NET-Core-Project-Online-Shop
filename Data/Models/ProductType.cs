namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static DataConstants.Product;

    public class ProductType
    {
        public int Id { get; init; }

        [Required]
        [StringLength(DefaultNameMaxLenght)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; init; } = new List<Product>();
    }
}
