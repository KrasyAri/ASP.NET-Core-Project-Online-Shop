namespace ASP.NET_Core_Project_Online_Shop.Services.Products.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductsDetailsServiceModel : ProductServiceModel
    {
        
        public string ProductCode { get; set; }

        public string Description { get; set; }

        //public string UserId { get; init; }

    }
}
