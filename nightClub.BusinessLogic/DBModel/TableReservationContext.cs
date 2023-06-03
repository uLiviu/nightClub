using nightClub.Domain.Entities.Contact;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Table;

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