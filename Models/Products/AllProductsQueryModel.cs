namespace ASP.NET_Core_Project_Online_Shop.Models.Products
{
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AllProductsQueryModel
    {

        public const int ProductsPerPage = 5;

        public string Name { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public ProductSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProducts { get; set; }

        public IEnumerable<string> ProductNames { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
    }
}
