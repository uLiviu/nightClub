using System;

namespace nightClub.Domain.Entities.Bar
{
    public class PhotoBar
    {
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
