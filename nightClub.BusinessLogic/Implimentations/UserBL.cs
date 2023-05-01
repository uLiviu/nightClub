using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Implimentations
{
    public class UserBL: AdminApi, IUser
    {
        public List<UserMinimal> GetList()
        {
            return GetUsers();
        }
    }
}
