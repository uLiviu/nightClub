using nightClub.Domain.Entities.User;
using nightClub.Domain.Enums;
using nightClub.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    public class UserDbInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<UDbTable>
            {
                new UDbTable
                {
                    Username = "Admin",
                    Email = "admin@gmail.com",
                    LasIp = "1",
                    LastLogin = DateTime.Now,
                    PhoneNumb = "000-000-0000",
                    Level = URole.Admin,
                    Password = LoginHelper.HashGen("admin123")
                },
                new UDbTable
                {
                    Username = "User1",
                    Email = "user1@gmail.com",
                    LasIp = "1",
                    LastLogin = DateTime.Now,
                    PhoneNumb = "111-111-1111",
                    Level = URole.User,
                    Password = LoginHelper.HashGen("user1123")
                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}
