using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IUser
    {
        List<UserMinimal> GetList();
    }
}
