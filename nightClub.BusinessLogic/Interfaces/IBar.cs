using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Bar;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IBar
    {
        List<PhotoBar> GetBars();
        UResponse Add(PhotoBar newPhoto);
    }
}
