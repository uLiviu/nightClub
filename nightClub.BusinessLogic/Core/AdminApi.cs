using AutoMapper;
using nightClub.BusinessLogic.DBModel;
using nightClub.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.Core
{
    public class AdminApi
    {
        internal List<UserMinimal> GetUsers()
        {
            List<UDbTable> users;
            var configure = new MapperConfiguration(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            IMapper mapper = configure.CreateMapper();

            using (var db = new UserContext())
            {
                users = db.Users.ToList();
            }
            return mapper.Map<List<UserMinimal>>(users);
        }


    }
}
