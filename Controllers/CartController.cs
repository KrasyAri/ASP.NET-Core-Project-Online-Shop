namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Services.Cart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Infrastructures.ClaimsPrincipalExtensions;

    public class CartController : Controller
    {

        private readonly ICartService cart;

        public CartController(ICartService cart)
            => this.cart = cart;

        [Authorize]
        public IActionResult MyShoppingCart(string userId)
        {
            if (this.User.Id() != userId)
            {
                return Unauthorized();
            }

            var userCartProducts = cart.UsersCart(userId);

            return View(userCartProducts);
        }
    }
}
