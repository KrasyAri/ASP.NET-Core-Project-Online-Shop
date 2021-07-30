namespace ASP.NET_Core_Project_Online_Shop.Models.TradePartners
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.TradePartner;

    public class BecomeTradePartnerFormModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = TradePartnerNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(BulstatMaxLenght, MinimumLength = BulstatMinLenght)]
        public string Bulstat { get; set; }

        [Required]
        [StringLength(CompanyNameMaxLenght, MinimumLength = CompanyNameMinLenght)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
