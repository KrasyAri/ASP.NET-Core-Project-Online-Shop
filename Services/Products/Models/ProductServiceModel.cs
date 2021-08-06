namespace ASP.NET_Core_Project_Online_Shop.Services.Products.Models
{
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Series Series { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category CategoryName { get; init; }
    }
}
