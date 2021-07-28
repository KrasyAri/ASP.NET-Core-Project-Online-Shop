namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TradePartner;

    public class TradePartner
    {
        public string Id { get; init; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(DefaultMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(BulstatMaxLenght)]
        public string Bulstat { get; set; }

        [Required]
        [MaxLength(CompanyNameMaxLenght)]
        public string CompanyName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
