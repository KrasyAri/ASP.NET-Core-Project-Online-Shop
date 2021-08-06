namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using System.ComponentModel.DataAnnotations;
 
    using static DataConstants.Product;

    public class Product
    {
        public int Id { get; init; }

        [Required]
        [StringLength(ProductCodeMaxLenght)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(ProductNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public double TradePartnerPrice { get; set; }

        [Required]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public int NetWeight { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Series Series { get; set; }

        public ProductType ProductType { get; set; }

        public Category Category { get; set; }

    }
}
