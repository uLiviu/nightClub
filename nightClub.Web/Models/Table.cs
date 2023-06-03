using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using nightClub.Domain.Enums;

namespace nightClub.Web.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Your Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "#of Guests")]
        [Range(1, 12, ErrorMessage = "Between 1 and 12 guests.")]
        public int GuestsNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Reservation { get; set; }

        [Required]
        [Display(Name = "Reservation Type")]
        public RType ReservationType { get; set; }

        [Display(Name = "Any special requests")]
        public string Description { get; set; }
    }
}