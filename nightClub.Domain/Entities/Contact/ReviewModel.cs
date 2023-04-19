using System;
using System.ComponentModel.DataAnnotations;

namespace nightClub.Domain.Entities.Contact
{
    public class ReviewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
