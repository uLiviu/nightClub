using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Implimentations
{
    public class StaffBL: ContentApi, IStaff
    {
        public List<StaffModel> GetStaff()
        {
            return GetStaffList();
        }

        public UResponse AddEmployee(StaffModel data)
        {
            return AddNewEmployee(data);
        }

        public StaffModel GetStaffById(int id)
        {
            return GetById(id);
        }

        public UResponse UpdateEmployee(int id, StaffModel data)
        {
            return Update(id, data);
        }

    }
}
