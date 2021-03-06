namespace ASP.NET_Core_Project_Online_Shop.Services.Products
{
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
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
            string tradePartnerPrice,
            string price,
            int quantity,
            int netWeight,
            string description,
            string imageUrl,
            Series series,
            ProductType productType,
            Category category);

        bool Edit(
            int id,
            string productCode,
            string name,
            string tradePartnerPrice,
            string price,
            int quantity,
            int netWeight,
            string description,
            string imageUrl,
            Series series,
            ProductType productType,
            Category category);

        bool Delete(int id);
        
        IEnumerable<NewestProductsServiceModel> NewestProducts();

        public ProductsDetailsServiceModel Details(int id);

        IEnumerable<string> AllProductNames();

    }
}
