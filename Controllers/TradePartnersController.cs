namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Models.TradePartners;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class TradePartnersController : Controller

    {
        private readonly OnlineShopDbContext data;

        public TradePartnersController(OnlineShopDbContext data) 
            => this.data = data;

        [Authorize]
        public IActionResult BecomeTradePartner() => View();

        [HttpPost]
        [Authorize]
        public IActionResult BecomeTradePartner(BecomeTradePartnerFormModel tradePartner)
        {
            var userId = this.User.Id();

            var userIdIsPartner = this.data.TradePartners.Any(d => userId == d.UserId);

            if (userIdIsPartner)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tradePartnerData = new TradePartner
            {
                Bulstat = tradePartner.Bulstat,
                CompanyName = tradePartner.CompanyName,
                PhoneNumber = tradePartner.PhoneNumber,
                UserId = userId
            };

            this.data.TradePartners.Add(tradePartnerData);
            this.data.SaveChanges();

            
            return RedirectToAction(nameof(ProductsController.All), "Products"); 
                
        }
    }
}
