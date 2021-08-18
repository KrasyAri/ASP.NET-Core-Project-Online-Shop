namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Services.Order;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {

        private readonly IOrderService orderService;

        public UserController(IOrderService orderService) 
            => this.orderService = orderService;

        [Authorize]
        public IActionResult MyOrders(string userId)
        {
            if (User.Id() != userId)
            {
                return BadRequest();
            }

            var orders = orderService.UsersOrders(userId);

            return View(orders);
        }
    }
}
