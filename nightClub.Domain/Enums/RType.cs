using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.Domain.Enums
{
    public enum RType
    {
        VIP = 0,
        General,
        Booth,
        Outdoor, //an outdoor area
        Group    //a reserved area with multiple tables, along with perks like priority entry, complimentary drinks, or special promotions. 
    }
}