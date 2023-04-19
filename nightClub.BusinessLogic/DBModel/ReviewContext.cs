using nightClub.Domain.Entities.Contact;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() :
            base("name=nightClub")
        { }

        public virtual DbSet<RDbTable> Reviews { get; set; }
    }
}
