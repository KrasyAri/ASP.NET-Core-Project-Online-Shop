namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Enums;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Areas.Admin.AdminConstants;

    public class ProductsController : Controller
    {
        private readonly OnlineShopDbContext data;
        private readonly IProductService products;

        public ProductsController(OnlineShopDbContext data, IProductService products)
        {
            this.data = data;
            this.products = products;
        }

        [Authorize]
        public IActionResult Add()
        {
            //if (!this.User.IsAdmin())
            //{
            //    return Unauthorized();
            //}
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(ProductFormModel product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            this.products.Create(
                product.ProductCode,
                product.Name,
                product.TradePartnerPrice,
                product.Price,
                product.Quantity,
                product.NetWeight,
                product.Description,
                product.ImageUrl,
                product.Series,
                product.ProductType,
                product.Category);

            return RedirectToAction(nameof(All));
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

        public IActionResult Details(int id, string information)
        {
             var product = this.products.Details(id);

               
                return View(product);
        }

    }
}
