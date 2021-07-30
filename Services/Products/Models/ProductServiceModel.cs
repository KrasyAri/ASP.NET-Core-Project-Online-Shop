namespace ASP.NET_Core_Project_Online_Shop.Services.Products.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Series { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public string CategoryName { get; init; }
    }
}
