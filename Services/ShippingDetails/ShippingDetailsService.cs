namespace ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails
{
    using ASP.NET_Core_Project_Online_Shop.Data;
    using ASP.NET_Core_Project_Online_Shop.Data.Models;

    public class ShippingDetailsService : IShippingDetailsService
    {
        private readonly OnlineShopDbContext data;
        public ShippingDetailsService(OnlineShopDbContext data) 
            => this.data = data;
        public int AddDetails(string country, string city, string adress, string phonenumber, string deliveryCompanyOffice, string additionalInfo, int orderId, string userId)
        {

            var shippingDetailsData = new ShippingDetails
            {
                Country = country,
                City = city,
                Adress = adress,
                PhoneNumber = phonenumber,
                DeliveryCompanyOffice = deliveryCompanyOffice,
                AdditionalInfo = additionalInfo,
                OrderId = orderId,
                UserId = userId
                
            };

            this.data.ShippingDetails.Add(shippingDetailsData);
            this.data.SaveChanges();

            return shippingDetailsData.Id;
        }
    }
}
