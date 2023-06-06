using nightClub.Domain.Entities.Table;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class TableReservationContext : DbContext
    {
        public TableReservationContext() :
            base("name=nightClub")
        {
        }
        public virtual DbSet<TRDbTable> Reservations { get; set; }
    }
}