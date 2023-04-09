using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.DBModel
{
    public class StaffContext : DbContext
    {
        public StaffContext() : base(
            "name=nightClub")
        {

        }

    }
}
