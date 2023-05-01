using nightClub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace nightClub.Domain.Entities.Staff
{
    public class StaffModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } //
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ImageUrl { get; set; } //
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumb { get; set; }
        [Required]
        public SRole Role { get; set; } //
        [Required]
        public double PayRate { get; set; }
        public string Description { get; set; }

    }
}
