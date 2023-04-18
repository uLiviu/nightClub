using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Contact;

namespace nightClub.BusinessLogic.DBModel
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() : 
            base("name=nightClub")
        { }

        public virtual DbSet<Review> Reviews { get; set; }
    }
}
