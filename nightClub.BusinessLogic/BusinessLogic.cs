using nightClub.BusinessLogic.Implimentations;
using nightClub.BusinessLogic.Interfaces;

namespace nightClub.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
