namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
       
        private readonly IProductService products;


        public ProductsController(IProductService products)
        {
            this.products = products;
        }

        public IActionResult All([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.All(
                query.Name,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllProductsQueryModel.ProductsPerPage);

            var productName = this.products.AllProductNames();

            query.ProductNames = productName;
            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;

            return View(query);
        }

        public IActionResult Details(int id)
        {
             var product = this.products.Details(id);

                return View(product);
        }
    }
}
