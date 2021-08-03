namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.ShippingDetails;

    public class ShippingDetails
    {

        [Required]
        [MaxLength(CountryMaxLenght)]
        public string Country { get; set; }

        [Required]
        [MaxLength(CityMaxLenght)]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(DeliveryCompanyMax)]
        public string DeliveryCompanyOffice { get; set; }

        public string AdditionalInfo { get; set; }
    }
}
