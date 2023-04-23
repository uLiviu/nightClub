using nightClub.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nightClub.Web.Models
{
    public class Staff 
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } //
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ImageUrl { get; set; } //
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumb { get; set; }
        [Required]
        public SRole Role { get; set; } //
        [Required]
        public double PayRate { get; set; }

      //  public string Description { get; set; }
    }
}