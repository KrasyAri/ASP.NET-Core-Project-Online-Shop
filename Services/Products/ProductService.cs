namespace ASP.NET_Core_Project_Online_Shop.Services.Products
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
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

        public ProductQueryServiceModel All(string name, string searchTerm, ProductSorting sorting, int currentPage, int productsPerPage)
        {
            var productsQuery = this.data.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                productsQuery = productsQuery.Where(p => p.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productsQuery = productsQuery.Where(p =>
                    (p.Name + " " + p.Series.Name).ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            productsQuery = sorting switch
            {
                ProductSorting.Name => productsQuery.OrderBy(p => p.Name),
                ProductSorting.Series => productsQuery.OrderBy(p => p.Series.Name),
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


        public IEnumerable<ProductCategoryServiceModel> AllCategories()
            => this.data
                .Categories
                .Select(c => new ProductCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public IEnumerable<ProductSeriesServiceModel> AllSeries()
            => this.data
                .Series
                .Select(s => new ProductSeriesServiceModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();

        public IEnumerable<ProductTypeServiceModel> AllProductTypes()
            => this.data
            .ProductTypes
            .Select(pt => new ProductTypeServiceModel
            {
                Id = pt.Id,
                Name = pt.Name
            })
            .ToList();

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
                  Series = p.Series.Name,
                  Price = p.Price,
                  ImageUrl = p.ImageUrl,
                  CategoryName = p.Category.Name
              })
              .ToList();

        public bool SeriesExist(int seriesId)
            => this.data
                .Series
                .Any(s => s.Id == seriesId);

        public bool ProdyctTypeExist(int productTypeId)
            => this.data
                .ProductTypes
                .Any(pt => pt.Id == productTypeId);

        public bool CategoryExists(int categoryId)
           => this.data
               .Categories
               .Any(p => p.Id == categoryId);

      
    }

}
