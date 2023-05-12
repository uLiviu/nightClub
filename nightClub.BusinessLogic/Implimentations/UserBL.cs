using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class UserBL : AdminApi, IUser
    {
        public List<UserMinimal> GetList(string searchCriteria)
        {
            return GetUsers(searchCriteria);
        }

        public UserMinimal GetById(int id)
        {
            return GetUserById(id);
        }
        public void Delete(int id)
        {
            DeleteUser(id);
        }
    }
}
