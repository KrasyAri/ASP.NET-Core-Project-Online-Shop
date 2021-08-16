namespace ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails.Models;
    using AutoMapper;
    using ASP.NET_Core_Project_Online_Shop.Infrastructures;

    public class ShippingDetailsService : IShippingDetailsService
    {
        private readonly OnlineShopDbContext data;
        public ShippingDetailsService(OnlineShopDbContext data) 
            => this.data = data;
        public int AddShippingDetails(string country, string city, string adress, string phonenumber, string deliveryCompanyOffice, string additionalInfo)
        {

            var shippingDetailsData = new ShippingDetails
            {
                Country = country,
                City = city,
                Adress = adress,
                PhoneNumber = phonenumber,
                DeliveryCompanyOffice = deliveryCompanyOffice,
                AdditionalInfo = additionalInfo
            };

            this.data.ShippingDetails.Add(shippingDetailsData);
            this.data.SaveChanges();

            return shippingDetailsData.Id;
        }
    }
}
