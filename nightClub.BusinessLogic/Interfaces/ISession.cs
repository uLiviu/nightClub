using nightClub.Domain.Entities.User;
using System.Web;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface ISession
    {
        UResponse UserLogin(ULoginData data);
        UResponse UserRegister(URegisterData data);
    }
}
