using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nightClub.Web.Models
{
    public class Review
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 20)]
        public string Subject { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 30)]
        public string Message { get; set; }
    }
}