using AutoMapper;
using nightClub.BusinessLogic.DBModel;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

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

        internal UserMinimal GetUserById(int id)
        {
            UDbTable user;
            using (var db = new UserContext())
                user = db.Users.FirstOrDefault(u => u.Id == id);
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<UDbTable, UserMinimal>()).CreateMapper();

            return user != null ? mapper.Map<UserMinimal>(user) : null;
        }
        internal void DeleteUser(int id)
        {
            using (var db = new UserContext())
            {
                var photo = db.Users.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                {
                    db.Users.Remove(photo);
                    db.SaveChanges();
                }
            }
        }
    }
}
