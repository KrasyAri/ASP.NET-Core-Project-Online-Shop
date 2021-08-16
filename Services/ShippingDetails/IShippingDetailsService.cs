namespace ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails
{
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails.Models;
  
    public interface IShippingDetailsService
    {
        public int AddShippingDetails(string country, string city, string adress, string phonenumber, string deliveryCompanyOffice, string additionalInfo);
    }
}
