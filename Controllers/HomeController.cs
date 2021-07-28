namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {

        private readonly OnlineShopDbContext data;

        public HomeController(OnlineShopDbContext data) => this.data = data;

        public IActionResult Index()
        {
            //if (!this.data.Products.Any())
            //{
            //    return View();
            //}

            //var products = this.data
            //    .Products
            //    .OrderByDescending(c => c.Id)
            //    .Take(5)
            //    .ToList();

            //return View(products);

            return View();
        }

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
