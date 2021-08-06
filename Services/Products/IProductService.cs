namespace ASP.NET_Core_Project_Online_Shop.Services.Products
{
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using System;
    using System.Collections.Generic;

    public interface IProductService
    {
        ProductQueryServiceModel All(
            string name,
            string searchTerm,
            ProductSorting sorting,
            int currentPage,
            int productsPerPage);

       
        int Create(
            string productCode,
            string name,
            double tradePartnerPrice,
            double price,
            int quantity,
            int netWeight,
            string description,
            string imageUrl,
            Series series,
            ProductType productType,
            Category category);

        IEnumerable<NewestProductsServiceModel> NewestProducts();

        public ProductsDetailsServiceModel Details(int id);

        IEnumerable<string> AllProductNames();

    }
}
