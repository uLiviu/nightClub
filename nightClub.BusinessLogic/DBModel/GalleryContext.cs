using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Gallery;

namespace nightClub.BusinessLogic.DBModel
{
    public class GalleryContext:DbContext
    {
        public GalleryContext() :
            base("name=nightClub")
        {

        }
        public virtual DbSet<PDbTable> Photos { get; set; }
    }
}
