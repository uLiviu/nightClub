using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.Domain.Entities.Staff
{
    public class SDbTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string ImageUrl { get; set; }
        public string ContactInfo { get; set; }
        public double PayRate { get; set; }

    }
}
