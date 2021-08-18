namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using ASP.NET_Core_Project_Online_Shop.Models.Home;
    using ASP.NET_Core_Project_Online_Shop.Services.Products;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {

        private readonly IProductService products;

        public HomeController(IProductService products) => this.products = products;

        public IActionResult Index()
        {
            var newestProducts = this.products
                .NewestProducts()
                .ToList();


            return View(new IndexViewModel
            {
                Products = newestProducts
            });

        }

        public IActionResult Contacts() => View();

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
