using System.ComponentModel.DataAnnotations;

namespace nightClub.Web.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be less 5 and longer than 30 characters.")]
        public string Credential { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}