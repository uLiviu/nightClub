using AutoMapper;
using nightClub.BusinessLogic.DBModel;
using nightClub.Domain.Entities.User;
using nightClub.Helpers;
using nightClub.BusinessLogic.DBModel;
using nightClub.Domain.Entities.User;
using nightClub.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using nightClub.Domain.Enums;

namespace nightClub.BusinessLogic.Core
{
    public class UserApi
    {
        internal UResponse UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new UResponse { Status = false, StatusMsg ="The Username or Password is Incorrect"};
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new UResponse { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new UResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())// cand facem schimbari la un context din baza de date
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new UResponse { Status = true };
            }
        }
        internal UResponse UserRegisterAction(URegisterData data)
        {
            UDbTable result;
            data.Level = URole.User;
            using (var db = new UserContext())
                result = db.Users.FirstOrDefault(u => u.Username == data.Username);
            if (result != null)
                return new UResponse { Status = false, StatusMsg = "The Username already taken!" };

            using (var db = new UserContext())
                result = db.Users.FirstOrDefault(u => u.Email == data.Email);
            if (result != null)
                return new UResponse { Status = false, StatusMsg = "Account with a such Email already exists!" };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<URegisterData, UDbTable>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id este generat automat in baza de date si nu trebuie mapat
                    .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LoginDateTime)) // Mapam proprietatea LoginDateTime catre LastLogin
                    .ForMember(dest => dest.LasIp, opt => opt.MapFrom(src => src.LoginIp)) // Mapam proprietatea LoginIp catre LasIp
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => LoginHelper.HashGen(src.Password))); //Mapam proprietatea Password  utilizând LoginHelper.HashGen() pe valoarea din câmpul Password din URegisterData.
            });
            IMapper mapper = config.CreateMapper();
            result = mapper.Map<UDbTable>(data);

            using (var db = new UserContext())
            {
                db.Users.Add(result);
                db.SaveChanges();
            }

            return new UResponse { Status = true };
        }

    }
}
//HOST, CONTENT TYPE, MINE, COOKIES -Sunt campurile protocolului HTTP 