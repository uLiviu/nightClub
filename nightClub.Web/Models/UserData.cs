using nightClub.Domain.Enums;
using System;

namespace nightClub.Web.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public URole Level { get; set; }
        public DateTime LastLogin { get; set; }
        public string PhoneNumb { get; set; }


    }
}