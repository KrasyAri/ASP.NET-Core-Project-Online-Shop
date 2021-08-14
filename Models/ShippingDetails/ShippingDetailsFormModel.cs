namespace ASP.NET_Core_Project_Online_Shop.Models.ShippingDetails
{
    
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.ShippingDetails;

    public class ShippingDetailsFormModel
    {
        [Required]
        [StringLength(CountryMaxLenght, MinimumLength =CountryMinLenght)]
        public string Country { get; set; }

        [Required]
        [StringLength(CityMaxLenght, MinimumLength = CityMinLenght)]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(DeliveryCompanyMax, MinimumLength = DeliveryCompanyMin)]
        public string DeliveryCompanyOffice { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

    }
}
