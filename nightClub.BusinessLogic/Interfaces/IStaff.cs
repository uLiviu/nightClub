using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IStaff
    {
        List<StaffModel> GetStaff();
        UResponse AddEmployee(StaffModel data);
        StaffModel GetStaffById(int id);
        UResponse UpdateEmployee(int id, StaffModel data);
    }
}
