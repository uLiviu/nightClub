using nightClub.Domain.Entities.User;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=nightClub") // connectionstring name define in your web.config
        {

        }
        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
