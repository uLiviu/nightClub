using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.Ticket;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class EventContext : DbContext
    {
        public EventContext() : base("name=nightClub")
        {
        }
        public virtual DbSet<EDbTable> Events { get; set; }
        public virtual DbSet<TDbTable> Tickets { get; set; }
    }
}
