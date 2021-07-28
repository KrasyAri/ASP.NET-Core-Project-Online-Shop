namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

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

        public IActionResult All()
        {
            return BadRequest();
        }
       
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add()
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new ProductFormModel
            {
                Categories = this.products.AllCategories()
            });
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add(ProductFormModel product)
        {
           
            if (!this.products.CategoryExists(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.products.AllCategories();

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
                product.SeriesId, 
                product.ProductTypeId, 
                product.CategoryId);

            return RedirectToAction(nameof(All));
        }

    }
}
