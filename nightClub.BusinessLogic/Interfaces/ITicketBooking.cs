using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Ticket;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface ITicketBooking
    {
        UResponse Book(int ticketEventId, TicketModel ticketModel);
        List<TicketModel> GetTicketsList();
        TicketModel GetById(int id);
        TicketModel GetByUserId(int userId);
        void Delete(int id);

    }
}
