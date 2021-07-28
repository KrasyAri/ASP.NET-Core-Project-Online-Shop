namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
 
    using static DataConstants.Product;

    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ProductCodeMaxLenght)]
        public int ProductCode { get; set; }

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

        public int SeriesId { get; set; }

        public Series Series { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
