namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails;
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    public class ShippingDetailsController : Controller
    {
        private readonly IShippingDetailsService shippingDetailsService;
        private readonly IMapper mapper;
        public ShippingDetailsController(IShippingDetailsService shippingDetailsService, IMapper mapper = null) 
        {
            
            this.shippingDetailsService = shippingDetailsService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult AddShippingDetails(string userId)
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddShippingDetails(ShippingDetailsFormModel shippingDetails, string userId)
        {

            if (!ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            this.shippingDetailsService.AddDetails(
               shippingDetails.Country,
               shippingDetails.City,
               shippingDetails.Adress,
               shippingDetails.PhoneNumber,
               shippingDetails.DeliveryCompanyOffice,
               shippingDetails.AdditionalInfo,
               shippingDetails.OrderId,
               shippingDetails.UserId
               
                );

            return RedirectToAction("FinnishOrder", "Order", new { id = userId});
        }
    }
}
