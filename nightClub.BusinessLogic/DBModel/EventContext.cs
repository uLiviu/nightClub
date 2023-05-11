using nightClub.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.DBModel
{
    public class EventContext : DbContext
    {
        public EventContext() : base("name=nightClub")
        {
        }
        public virtual DbSet<EDbTable> Events { get; set; }
    }
}
