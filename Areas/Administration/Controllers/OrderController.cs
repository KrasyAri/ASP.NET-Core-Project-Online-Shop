namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Controllers
{
    using ASP.NET_Core_Project_Online_Shop.Areas.Administration.Models;
    using ASP.NET_Core_Project_Online_Shop.Areas.Administration.Services;
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Services.TradePartners;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    public class OrderController : Controller
    {
        
        private readonly IAllOrdersService allOrdersService;
        private readonly IMapper mapper;

        public OrderController(
            IMapper mapper, 
            IAllOrdersService allOrdersService)
        {
            this.mapper = mapper;
            this.allOrdersService = allOrdersService;
        }

        //public IActionResult AllUsersOrders()
        //{

        //    var orders = allOrdersService.UsersOrders();

        //    return View(orders);
        //}

        //public IActionResult AllTradePartnersOrders()
        //{
        //    var orders = allOrdersService.TradePartnersOrders();

        //    return View(orders);
        //}

    }

}
