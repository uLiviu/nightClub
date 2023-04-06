using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("nightClub")
        {
        }


    }

}
