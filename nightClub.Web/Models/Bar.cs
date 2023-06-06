using System;
using System.ComponentModel.DataAnnotations;

namespace nightClub.Web.Models
{
    public class Bar
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Alcohol { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}