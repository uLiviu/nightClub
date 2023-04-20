using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Staff;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IStaff
    {
        List<StaffModel> GetStaff();
    }
}
