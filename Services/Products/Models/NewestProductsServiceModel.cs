namespace ASP.NET_Core_Project_Online_Shop.Services.Products.Models
{
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewestProductsServiceModel
    {
        public int Id { get; init; }

        public string ProductCode { get; set; }

        public string Name { get; init; }

        public Series Series { get; init; }

        public string ImageUrl { get; init; }

        public decimal Price { get; init; }
    }
}
