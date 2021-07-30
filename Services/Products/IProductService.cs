namespace ASP.NET_Core_Project_Online_Shop.Services.Products
{
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
            int productCode,
            string name,
            double tradePartnerPrice,
            double price,
            int quantity,
            int netWeight,
            string description,
            string imageUrl,
            int seriesId,
            int productTypeId,
            int categoryId);
       
        //IEnumerable<NewestProductsServiceModel> Newest();

        IEnumerable<ProductCategoryServiceModel> AllCategories();

        IEnumerable<string> AllProductNames();

        bool CategoryExists(int categoryId);
    }
}
