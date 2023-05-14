using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Enums;
using static System.Net.WebRequestMethods;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    public class StaffDbInitializer: CreateDatabaseIfNotExists<StaffContext>
    {
        protected override void Seed(StaffContext context)
        {
            var femaleImg = "https://cdn.icon-icons.com/icons2/1999/PNG/512/avatar_people_person_profile_user_woman_icon_123368.png";
            var maleImg = "https://cdn.icon-icons.com/icons2/2468/PNG/512/user_kids_avatar_user_profile_icon_149314.png";
            var employees = new List<SDbTable>()
            {
                new SDbTable
                {
                    FirstName = "John",
                    LastName = "Doe",
                    ImageUrl = maleImg,
                    Address = "123 Main St.",
                    PhoneNumb = "555-555-1234",
                    Role = SRole.Manager,
                    PayRate = 50.00,
                    Description = "Experienced manager with 5 years of experience in the restaurant industry."
                },
                new SDbTable
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    ImageUrl = femaleImg,
                    Address = "456 Oak Ave.",
                    PhoneNumb = "555-555-5678",
                    Role = SRole.Waiter,
                    PayRate = 18.00,
                    Description = "Friendly and hard-working waiter with excellent customer service skills"
                },
                new SDbTable
                {
                    FirstName = "Bob",
                    LastName = "Johnson",
                    ImageUrl = maleImg,
                    Address = "789 Elm St.",
                    PhoneNumb = "555-555-9012",
                    Role = SRole.Barman,
                    PayRate = 20.00,
                    Description = "Experienced bartender with extensive knowledge of cocktails and spirits."
                },
                new SDbTable
                {
                    FirstName = "Sara",
                    LastName = "Davis",
                    ImageUrl = femaleImg,
                    Address = "1010 Pine St.",
                    PhoneNumb = "555-555-3456",
                    Role = SRole.Dancer,
                    PayRate = 20.00,
                    Description = "Professional dancer with experience in various dance styles and performances."
                },
                new SDbTable
                {
                    FirstName = "David",
                    LastName = "Lee",
                    ImageUrl = maleImg,
                    Address = "1212 Maple Ave.",
                    PhoneNumb = "555-555-7890",
                    Role = SRole.Dj,
                    PayRate = 30.00,
                    Description = "Skilled DJ with experience in different music genres and venues."
                }
            };
            employees.ForEach(e=> context.Staff.Add(e));
            context.SaveChanges();
        }
    }
}
