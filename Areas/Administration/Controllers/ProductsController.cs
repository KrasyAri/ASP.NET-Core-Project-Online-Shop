namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    using static Data.WebConstants;

    [Area("Administration")]
    public class ProductsController : Controller
    {
        private readonly OnlineShopDbContext data;
        private readonly IProductService products;
        private readonly IMapper mapper;

        public ProductsController(
            OnlineShopDbContext data, 
            IProductService products, 
            IMapper mapper)
        {
            this.data = data;
            this.products = products;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return this.View();
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

        [Authorize]
        public IActionResult Edit(int id)
        {
            var product = this.products.Details(id);
            var productForm = this.mapper.Map<ProductFormModel>(product);


            return View(productForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, ProductFormModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var edited = this.products.Edit(
                id,
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

            this.TempData[MessageKey] = "Successfully edited product";

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var productForDelete = this.products.Details(id);

            //var deleted = this.products.Delete(id);

            return View(productForDelete);
        }

        [Authorize]
        [HttpPost, ActionName("Confirm Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = this.products.Details(id);

            var deleted = this.products.Delete(id);

            this.TempData[MessageKey] = "Successfully deleted product";

            return RedirectToAction(nameof(All));
        }
    }
}
