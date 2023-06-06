using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nightClub.Domain.Entities.Bar
{
    public class BarDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public double Alcohol { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
