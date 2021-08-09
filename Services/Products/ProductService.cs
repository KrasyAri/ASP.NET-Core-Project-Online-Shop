namespace ASP.NET_Core_Project_Online_Shop.Services.Products
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly OnlineShopDbContext data;
        private readonly IConfigurationProvider mapper;

        public ProductService(
            OnlineShopDbContext data,
            IConfigurationProvider mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public ProductQueryServiceModel All(
            string name = null, 
            string searchTerm = null, 
            ProductSorting sorting = ProductSorting.DateCreated, 
            int currentPage = 1, 
            int productsPerPage = int.MaxValue)
        {
            var productsQuery = this.data.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                productsQuery = productsQuery.Where(p => p.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productsQuery = productsQuery.Where(p =>
                    (p.Name + " " + p.Series).ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            productsQuery = sorting switch
            {
                ProductSorting.Name => productsQuery.OrderBy(p => p.Name),
                ProductSorting.Series => productsQuery.OrderBy(p => p.Series.ToString()),
                ProductSorting.DateCreated or _ => productsQuery.OrderByDescending(c => c.Id)
            };

            var totalProducts = productsQuery.Count();

            var products = GetProducts(productsQuery
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage));

            return new ProductQueryServiceModel
            {
                TotalProducts = totalProducts,
                CurrentPage = currentPage,
                ProductsPerPage = productsPerPage,
                Products = products
            };
        }


        public int Create(string productCode, string name, string tradePartnerPrice, string price, int quantity, int netWeight, string description, string imageUrl, Series series, ProductType productType, Category category)
        {
           
            var productData = new Product
            {
                ProductCode = productCode,
                Name = name,
                TradePartnerPrice = decimal.Parse(tradePartnerPrice),
                Price = decimal.Parse(price),
                Quantity = quantity,
                NetWeight = netWeight,
                Description = description,
                ImageUrl = imageUrl,
                Series = series,
                ProductType = productType,
                Category = category
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return productData.Id;
        }

        public bool Edit(int id, string productCode, string name, string tradePartnerPrice, string price, int quantity, int netWeight, string description, string imageUrl, Series series, ProductType productType, Category category)
        {
            var productData = this.data.Products.Find(id);

            productData.ProductCode = productCode;
            productData.Name = name;
            productData.TradePartnerPrice = decimal.Parse(tradePartnerPrice);
            productData.Price = decimal.Parse(price);
            productData.Quantity = quantity;
            productData.NetWeight = netWeight;
            productData.Description = description;
            productData.ImageUrl = imageUrl;
            productData.Series = series;
            productData.ProductType = productType;
            productData.Category = category;

            this.data.SaveChanges();

            return true;
                    
        }

        public bool Delete(int id)
        {
            var productForDelete = this.data.Products.Find(id);

            this.data.Products.Remove(productForDelete);
            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<NewestProductsServiceModel> NewestProducts()
            => this.data
                .Products
                .OrderByDescending(c => c.Id)
                .ProjectTo<NewestProductsServiceModel>(this.mapper)
                .Take(5)
                .ToList();

        public ProductsDetailsServiceModel Details(int id)
            => this.data
                .Products
                .Where(c => c.Id == id)
                .ProjectTo<ProductsDetailsServiceModel>(this.mapper)
                .FirstOrDefault();

        public IEnumerable<string> AllProductNames()
            => this.data
                .Products
                .Select(p => p.Name)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

        private static IEnumerable<ProductServiceModel> GetProducts(IQueryable<Product> productQuery)
            => productQuery
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Series = p.Series,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category
                })
                .ToList();

       
    }

}
