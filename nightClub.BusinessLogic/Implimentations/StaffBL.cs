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
            return GetList();
        }

        public UResponse AddEmployee(StaffModel data)
        {
            return AddNewEntity(data);
        }

        public StaffModel GetStaffById(int id)
        {
            return GetEmployee(id);
        }

        public UResponse UpdateEmployee(StaffModel data)
        {
            return Update(data);
        }

        public void DeleteEmployee(int id)
        {
            DeleteStaff(id);
        }

    }
}
