namespace ASP.NET_Core_Project_Online_Shop.Services
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly OnlineShopDbContext data;
        public IEnumerable<ProductCategoryServiceModel> AllCategories()
            => this.data
                .Categories
                .Select(c => new ProductCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.data
                .Categories
                .Any(c => c.Id == categoryId);

        public int Create(int productCode, string name, double tradePartnerPrice, double price, int quantity, int netWeight, string description, string imageUrl, int seriesId, int productTypeId, int categoryId)
        {
            var productData = new Product
            {
                ProductCode = productCode,
                Name = name,
                TradePartnerPrice = tradePartnerPrice,
                Price = price,
                Quantity = quantity,
                NetWeight = netWeight,
                Description = description,
                ImageUrl = imageUrl,
                SeriesId = seriesId,
                ProductTypeId = productTypeId,
                CategoryId = categoryId
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return productData.Id;
        }
    }
}
