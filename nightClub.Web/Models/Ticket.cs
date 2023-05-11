using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace nightClub.Web.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the quantity of tickets you wish to purchase.")]
        [Range(1, 10, ErrorMessage = "The {0} must be between {1} and {2}.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int EventId { get; set; }

    }
}