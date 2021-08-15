namespace ASP.NET_Core_Project_Online_Shop.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    public class CartItem
    {
        [Key]
        //TODO: Check 
        public string ItemId { get; set; }

        [Required]
        public string UserId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string ProductImage { get; set; }
    }
}
