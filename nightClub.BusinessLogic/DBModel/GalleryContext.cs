using nightClub.Domain.Entities.Gallery;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel
{
    public class GalleryContext : DbContext
    {
        public GalleryContext() :
            base("name=nightClub")
        {

        }
        public virtual DbSet<PDbTable> Photos { get; set; }
    }
}
