using System;

namespace nightClub.Domain.Entities.Event
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double TicketPrice { get; set; }
        public int TotalTicketsNumber { get; set; }
        public int TicketsLeft { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialGuest { get; set; }
    }
}
