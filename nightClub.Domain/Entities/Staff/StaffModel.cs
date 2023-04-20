using nightClub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.Domain.Entities.Staff
{
    public class StaffModel
    {
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

    }
}
