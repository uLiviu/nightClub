using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nightClub.Web.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double TicketPrice { get; set; }
        [Required]
        public int TotalTicketsNumber { get; set; }
        public int TicketsLeft { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [Required] public DateTime StartDate { get; set; }

        [Required] public DateTime EndDate { get; set; }

        [Required]
        public string SpecialGuest { get; set; }
    }
}