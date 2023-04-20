using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Staff;

namespace nightClub.BusinessLogic.Implimentations
{
    public class StaffBL: ContentApi, IStaff
    {
        public List<StaffModel> GetStaff()
        {
            return GetStaffList();
        }

    }
}
