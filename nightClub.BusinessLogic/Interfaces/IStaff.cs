using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IStaff
    {
        List<StaffModel> GetStaff();
        UResponse AddEmployee(StaffModel data);
        StaffModel GetStaffById(int id);
        UResponse Update(StaffModel data);
        void Delete(int id);
    }
}
