namespace ASP.NET_Core_Project_Online_Shop.Models.Home
{
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IList<NewestProductsServiceModel> Products { get; init; }
    }
}
