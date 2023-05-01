using nightClub.Domain.Entities.Staff;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class StaffContext : DbContext
    {
        public StaffContext() : base(
            "name=nightClub")
        {

        }
        public virtual DbSet<SDbTable> Staff { get; set; }
    }
}
