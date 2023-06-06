using nightClub.Domain.Entities.Bar;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class BarContext : DbContext
    {
        public BarContext() :
            base("name=nightClub")
        {

        }
        public virtual DbSet<BarDbTable> Bars { get; set; }
    }
}
