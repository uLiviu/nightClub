using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.User;
using System.Web;

namespace nightClub.BusinessLogic.Implimentations
{
    public class SessionBL : UserApi, ISession
    {
        public UResponse UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
        public UResponse UserRegister(URegisterData data)
        {
            return UserRegisterAction(data);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
