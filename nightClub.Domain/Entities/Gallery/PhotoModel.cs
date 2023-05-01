using System;

namespace nightClub.Domain.Entities.Gallery
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
