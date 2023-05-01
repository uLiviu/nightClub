using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IUser
    {
        List<UserMinimal> GetList();
        UserMinimal GetById(int id);
        void Delete(int id);
    }
}
