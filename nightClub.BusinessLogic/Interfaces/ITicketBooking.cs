using nightClub.Domain.Entities.Ticket;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface ITicketBooking
    {
        UResponse Book(int ticketEventId, TicketModel ticketModel);
        List<TicketModel> GetTicketsList(string searchCriteria);
        TicketModel GetById(int id);
        List<TicketModel> GetByUserId(int userId, int? eventId);
        void Delete(int id);

    }
}
