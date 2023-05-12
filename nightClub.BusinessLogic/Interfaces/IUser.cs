using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IUser
    {
        List<UserMinimal> GetList(string searchCriteria);
        UserMinimal GetById(int id);
        void Delete(int id);
    }
}
