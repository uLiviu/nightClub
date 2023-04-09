using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Staff;

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
