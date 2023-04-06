using nightClub.Domain.Entities.User;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=nightClub") // connectionstring name define in your web.config
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
