using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class StaffBL : ContentApi, IStaff
    {
        public List<StaffModel> GetStaff()
        {
            return GetList();
        }

        public UResponse AddEmployee(StaffModel data)
        {
            return AddStaff(data);
        }

        public StaffModel GetStaffById(int id)
        {
            return GetEmployee(id);
        }

        public UResponse Update(StaffModel data)
        {
            return UpdateEmployee(data);
        }

        public void Delete(int id)
        {
            DeleteEmployee(id);
        }

    }
}
