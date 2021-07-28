namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Product;

    public class Series
    {
        public int Id { get; init; }

        [Required]
        [StringLength(DefaultNameMaxLenght)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; init; } = new List<Product>();
    }
}
