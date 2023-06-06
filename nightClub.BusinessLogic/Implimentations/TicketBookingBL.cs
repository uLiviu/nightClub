using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Ticket;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class TicketBookingBL : ContentApi, ITicketBooking
    {
        //Create
        public UResponse Book(int ticketEventId, TicketModel ticketModel)
        {
            return BookTicket(ticketEventId, ticketModel);
        }

        //Read
        public List<TicketModel> GetTicketsList(string searchCriteria)
        {
            return GetAllTicketBookings(searchCriteria);
        }

        public TicketModel GetById(int id)
        {
            return GetTicketById(id);
        }
        public List<TicketModel> GetByUserId(int userId, int? eventId)
        {
            return GetTicketUserById(userId, eventId);
        }

        //Delete
        public void Delete(int id)
        {
            DeleteTicket(id);
        }
    }
}
