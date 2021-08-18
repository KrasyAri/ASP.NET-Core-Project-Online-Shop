namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Services.Order;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ASP.NET_Core_Project_Online_Shop.Data.WebConstants;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService) 
            => this.orderService = orderService;

        [Authorize]
        public IActionResult OrderDetails(string id)
        {
            var details = orderService.OrderDetailsFromCart(id);

            if (details == null)
            {
                return RedirectToAction("All", "Products");
            }

            return View(details);
        }

        [Authorize]
        public IActionResult FinnishOrder(string id)
        {
            if (User.Id() != id)
            {
                return BadRequest();
            }

            int orderId = orderService.CreateOrderInTheDatabase(id);


            var success = orderService.FinnishOrder(id, orderId);

            if (success)
            {
                this.TempData[MessageKey] = "Your order is successfuly finised!";
                return RedirectToAction("MyOrders", "User", new { userId = id });
            }

            this.TempData[MessageKey] = "No products in you Cart!";
            return RedirectToAction("All", "Products");
        }
    }
}
