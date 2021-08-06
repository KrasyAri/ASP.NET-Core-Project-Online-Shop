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
            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;

            return View(query);
        }


        public IActionResult Add()
        {
            //if (!this.User.IsAdmin())
            //{
            //    return Unauthorized();
            //}
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
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

    }
}
