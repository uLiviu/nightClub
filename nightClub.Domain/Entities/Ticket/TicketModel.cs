namespace nightClub.Domain.Entities.Ticket
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int EventId { get; set; }
    }
}
