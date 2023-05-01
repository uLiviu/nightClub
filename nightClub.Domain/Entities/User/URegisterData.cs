using nightClub.Domain.Enums;
using System;

namespace nightClub.Domain.Entities.User
{
    public class URegisterData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumb { get; set; }
        public URole Level { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
