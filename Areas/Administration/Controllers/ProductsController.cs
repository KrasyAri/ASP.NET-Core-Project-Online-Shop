namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
 
    [Area("Administration")]
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
