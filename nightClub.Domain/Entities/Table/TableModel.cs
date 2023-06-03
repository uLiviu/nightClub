using nightClub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace nightClub.Domain.Entities.Table
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GuestsNumber { get; set; }
        public DateTime Reservation { get; set; }
        public RType ReservationType { get; set; }
        public string Description { get; set; }
    }
}