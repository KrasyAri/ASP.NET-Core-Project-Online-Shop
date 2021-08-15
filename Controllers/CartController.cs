namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Services.Cart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Infrastructures.ClaimsPrincipalExtensions;

    using static Data.WebConstants;

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

        public IActionResult AddToCart(int productId, string userId)
        {
            if (userId != User.Id())
            {
                return Unauthorized();
            }

            var success = cart.AddToCart(productId, userId);

            if (success)
            {
                this.TempData[MessageKey] = "Product was successfully added to Your cart";
            }
            else
            {
                this.TempData[MessageKey] = "No product added to your cart!";
            }

            return RedirectToAction("All", "Products");
        }

        [Authorize]
        public IActionResult Add(int productId, string userId)
        {
            if (userId != User.Id())
            {
                return Unauthorized();
            }

            cart.AddQuantity(productId, userId);

            return RedirectToAction("MyShoppingCart", new { userId = userId });
        }

        [Authorize]
        public IActionResult Remove(int productId, string userId)
        {
            if (userId != User.Id())
            {
                return BadRequest();
            }

            cart.RemoveQuantity(productId, userId);

            return RedirectToAction("MyShoppingCart", new { userId = userId });
        }

        [Authorize]
        public IActionResult Delete(int productId, string userId)
        {
            if (userId != User.Id())
            {
                return Unauthorized();
            }

            cart.Delete(productId, userId);

            this.TempData[MessageKey] = "Successfully removed product from Your cart";

            return RedirectToAction("MyShoppingCart", new { userId = userId });
        }


    }
}
