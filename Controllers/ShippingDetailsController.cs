namespace ASP.NET_Core_Project_Online_Shop.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails;
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        public IActionResult AddShippingDetails()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddShippingDetails(ShippingDetailsFormModel shippingDetails)
        {

            if (!ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            this.shippingDetailsService.AddShippingDetails(
               shippingDetails.Country,
               shippingDetails.City,
               shippingDetails.Adress,
               shippingDetails.PhoneNumber,
               shippingDetails.DeliveryCompanyOffice,
               shippingDetails.AdditionalInfo
                );

            return RedirectToAction("FinnishOrder", "Order");
        }
    }
}
