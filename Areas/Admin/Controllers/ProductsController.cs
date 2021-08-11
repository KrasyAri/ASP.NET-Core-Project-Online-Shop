namespace ASP.NET_Core_Project_Online_Shop.Areas.Admin.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AdminConstants;
    public class ProductsController : AdminController
    {
        private readonly IProductService products;
        public ProductsController(IProductService products)
            => this.products = products;


        public IActionResult Index() => View();


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
            query.Products = queryResult.Products;

            return View(query);
        }

    }
}
