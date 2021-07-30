namespace ASP.NET_Core_Project_Online_Shop.Services.Products.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewestProductsServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Series { get; init; }

        public string ImageUrl { get; init; }

        public double Price { get; init; }
    }
}
