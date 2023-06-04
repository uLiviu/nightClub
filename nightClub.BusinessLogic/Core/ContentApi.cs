using AutoMapper;
using nightClub.BusinessLogic.DBModel;
using nightClub.BusinessLogic.Implimentations;
using nightClub.Domain.Entities.Contact;
using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Entities.Ticket;
using nightClub.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
using nightClub.Helpers;
using nightClub.Domain.Entities.Table;
using nightClub.Domain.Enums;
using nightClub.Domain.Entities.Bar;

namespace nightClub.BusinessLogic.Core
{
    public class ContentApi
    {
        //Get List
        internal List<ReviewModel> GetReviewList()
        {
            List<RDbTable> context;
            
            IMapper mapper = MappingHelper.Configure<RDbTable, ReviewModel>();

            using (var db = new ReviewContext())
            {
                context = db.Reviews.ToList();
            }
            var reviewModel = mapper.Map<List<ReviewModel>>(context);
            return reviewModel;
        }

        internal List<StaffModel> GetStaffList()
        {
            List<SDbTable> context;

            var mapper = MappingHelper.Configure<SDbTable, StaffModel>();
            using (var db = new StaffContext())
            {
                context = db.Staff.ToList();
            }
            return mapper.Map<List<StaffModel>>(context);
        }
        internal List<PhotoModel> GetAllPhoto()
        {
            List<PDbTable> context;

            var mapper = MappingHelper.Configure<PDbTable, PhotoModel>();
            using (var db = new GalleryContext())
            {
                context = db.Photos.ToList();
            }
            return mapper.Map<List<PhotoModel>>(context);
        }
        internal List<EventModel> GetAllEvents()
        {
            List<EDbTable> context;

            var mapper = MappingHelper.Configure<EDbTable, EventModel>();
            using (var db = new EventContext())
            {
                context = db.Events.ToList();
            }
            return mapper.Map<List<EventModel>>(context);
        }
        internal List<TicketModel> GetAllTicketBookings(string searchCriteria)
        {
            List<TDbTable> context;

            var mapper =MappingHelper.Configure<TDbTable, TicketModel>();
            using (var db = new EventContext())
            {
                if (!string.IsNullOrEmpty(searchCriteria))
                {
                    if (int.TryParse(searchCriteria, out int searchInt))
                    {
                        // Search by integer if the search criteria is a valid integer
                        context = db.Tickets.Where(e => e.EventId == searchInt).ToList();
                    }
                    else
                    {
                        // Search by string if the search criteria is not a valid integer
                        context = db.Tickets.Where(e => e.FullName.Contains(searchCriteria)).ToList();
                    }
                }
                else
                {
                    context = db.Tickets.ToList();
                }
            }
            return mapper.Map<List<TicketModel>>(context);
        }
        internal List<TableModel> GetReservationList(string searchCriteria)
        {
            List<TRDbTable> reservations;
            var mapper = MappingHelper.Configure<TRDbTable, TableModel>();
            using (var db = new TableReservationContext())
            {
                if (!string.IsNullOrEmpty(searchCriteria))
                {
                    if (Enum.TryParse(searchCriteria, out RType searchInt))
                    {
                        // Search by integer if the search criteria is a valid integer
                        reservations = db.Reservations.Where(e => e.ReservationType == searchInt).ToList();
                    }
                    else
                    {
                        // Search by string if the search criteria is not a valid integer
                        reservations = db.Reservations.Where(u => u.Username.Contains(searchCriteria)).ToList();
                    }
                }
                else
                {
                    reservations = db.Reservations.ToList();
                }
            }
            return mapper.Map<List<TableModel>>(reservations);
        }

        //AddNewEntity
        internal void AddNewReview(ReviewModel review)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewModel, RDbTable>();
            });
            IMapper mapper = config.CreateMapper();
            var result = mapper.Map<RDbTable>(review);

            using (var db = new ReviewContext())
            {
                db.Reviews.Add(result);
                db.SaveChanges();
            }
        }
        internal UResponse AddNewEmployee(StaffModel data)
        {
            SDbTable context;

            using (var db = new StaffContext())
                context = db.Staff.FirstOrDefault(u => u.PhoneNumb == data.PhoneNumb);
            if (context != null)
                return new UResponse { Status = false, StatusMsg = "Employee already added!" };

            IMapper mapper =MappingHelper.Configure<StaffModel, SDbTable>();
            context = mapper.Map<SDbTable>(data);

            using (var db = new StaffContext())
            {
                db.Staff.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        internal UResponse AddPhoto(PhotoModel photo)
        {
            IMapper mapper =MappingHelper.Configure<PhotoModel, PDbTable>();
            PDbTable context = mapper.Map<PDbTable>(photo);

            context.Date = DateTime.Now;
            using (var db = new GalleryContext())
            {
                db.Photos.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
        internal UResponse AddEvent(EventModel newEvent)
        {
            IMapper mapper =MappingHelper.Configure<EventModel, EDbTable>();
            var context = mapper.Map<EDbTable>(newEvent);
            context.TicketsLeft = context.TotalTicketsNumber;
            using (var db = new EventContext())
            {
                db.Events.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
        internal UResponse BookTicket(int ticketEventId, TicketModel ticketModel)
        {
            EDbTable eventEF;
            using (var db = new EventContext())
            {
                eventEF = db.Events.FirstOrDefault(e => e.Id == ticketEventId);
            }
            if (eventEF == null)
            {
                throw new ArgumentException($"The event with ID {ticketEventId} does not exist.");
            }
            if (eventEF.TicketsLeft < ticketModel.Quantity)
            {
                return new UResponse { Status = false, StatusMsg = $"There are not enough tickets available for the event {eventEF.Title}." };
            }
            ticketModel.TotalPrice = ticketModel.Quantity * eventEF.TicketPrice;

            IMapper mapper = MappingHelper.Configure<TicketModel, TDbTable>();
            var ticketEF = mapper.Map<TDbTable>(ticketModel);

            using (var db = new EventContext())
            {
                eventEF.TicketsLeft -= ticketEF.Quantity;
                db.Tickets.Add(ticketEF);
                db.Entry(eventEF).State = EntityState.Modified;
                db.SaveChanges();
            }

            return new UResponse { Status = true };
        }
        internal UResponse AddTableReservation(TableModel tableModel)
        {
            TRDbTable context;
            using (var db = new TableReservationContext())
            {
                context = db.Reservations.FirstOrDefault(t => t.Username == tableModel.Username && t.Reservation == tableModel.Reservation);
            }

            if (context != null)
            {
                return new UResponse { Status = false, StatusMsg = "You already have a reservation on this date!" };
            }

            var mapper = MappingHelper.Configure<TableModel, TRDbTable>();
            context = mapper.Map<TRDbTable>(tableModel);
            using (var db = new TableReservationContext())
            {
                db.Reservations.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        //GetById
        internal StaffModel GetEmployee(int id)
        {
            SDbTable context;
            using (var db = new StaffContext())
                context = db.Staff.FirstOrDefault(u => u.Id == id);
            IMapper mapper =MappingHelper.Configure<SDbTable, StaffModel>();

            return context != null ? mapper.Map<StaffModel>(context) : null;
        }
        internal PhotoModel GetPhotoById(int id)
        {
            PDbTable context;
            using (var db = new GalleryContext())
                context = db.Photos.FirstOrDefault(u => u.Id == id);
            IMapper mapper =MappingHelper.Configure<PDbTable, PhotoModel>();

            return context != null ? mapper.Map<PhotoModel>(context) : null;
        }
        internal EventModel GetEventById(int id)
        {
            EDbTable context;
            using (var db = new EventContext())
                context = db.Events.FirstOrDefault(u => u.Id == id);
            IMapper mapper =MappingHelper.Configure<EDbTable, EventModel>();

            return context != null ? mapper.Map<EventModel>(context) : null;
        }
        internal TicketModel GetTicketById(int id)
        {
            TDbTable context;
            using (var db = new EventContext())
                context = db.Tickets.FirstOrDefault(u => u.Id == id);
            IMapper mapper =MappingHelper.Configure<TDbTable, TicketModel>();

            return context != null ? mapper.Map<TicketModel>(context) : null;
        }
        internal List<TicketModel> GetTicketUserById(int userId, int? eventId)
        {
            List<TDbTable> context;
            using (var db = new EventContext())
            {
                if (eventId.HasValue)
                {
                    context = db.Tickets.Where(t => (t.UserId == userId && t.EventId == eventId)).ToList();
                }
                else
                {
                    context = db.Tickets.Where(b => b.UserId == userId).ToList();
                }
            }
            var mapper =MappingHelper.Configure<TDbTable, TicketModel>();
            return mapper.Map<List<TicketModel>>(context);
        }
        internal TableModel GetTableReservationById(int id)
        {
            TRDbTable context;
            using (var db = new TableReservationContext())
                context = db.Reservations.FirstOrDefault(u => u.Id == id);
            var mapper = MappingHelper.Configure<TRDbTable, TableModel>();
            return context != null ? mapper.Map<TableModel>(context) : null;
        }

        //Update
        internal UResponse UpdateEmployee(StaffModel data)
        {
            if (GetEmployee(data.Id) == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            IMapper mapper =MappingHelper.Configure<StaffModel, SDbTable>();
            var result = mapper.Map<SDbTable>(data);

            using (var db = new StaffContext())
            {
                db.Staff.AddOrUpdate(result);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
        internal UResponse UpdatePhoto(PhotoModel data)
        {
            if (GetPhotoById(data.Id) == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            IMapper mapper =MappingHelper.Configure<PhotoModel, PDbTable>();
            var result = mapper.Map<PDbTable>(data);
            result.Date = DateTime.Now;

            using (var db = new GalleryContext())
            {
                db.Photos.AddOrUpdate(result);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
        internal UResponse UpdateEvent(EventModel data)
        {
            EventModel currentEvent = GetEventById(data.Id);
            if (currentEvent == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            int bookedTickets = currentEvent.TotalTicketsNumber - currentEvent.TicketsLeft;
            if (data.TotalTicketsNumber < bookedTickets)
            {
                return new UResponse { Status = false, StatusMsg = $"This amount of tickets is allready booked. {bookedTickets} tickets!" };
            }

            IMapper mapper =MappingHelper.Configure<EventModel, EDbTable>();
            var result = mapper.Map<EDbTable>(data);

            using (var db = new EventContext())
            {
                result.TicketsLeft = result.TotalTicketsNumber - bookedTickets;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        //Delete
        internal void DeleteEmployee(int id)
        {
            using (var db = new StaffContext())
            {
                var staff = db.Staff.FirstOrDefault(u => u.Id == id);
                if (staff != null)
                {
                    db.Staff.Remove(staff);
                    db.SaveChanges();
                }
            }
        }
        internal void DeletePhoto(int id)
        {
            using (var db = new GalleryContext())
            {
                var photo = db.Photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                {
                    db.Photos.Remove(photo);
                    db.SaveChanges();
                }
            }
        }
        internal void DeleteEvent(int id)
        {
            using (var db = new EventContext())
            {
                var entity = db.Events.FirstOrDefault(p => p.Id == id);
                if (entity == null) return;

                //Sterge toate rezervarile la acest eveniment
                var tickets = db.Tickets.Where(p => p.EventId == id).ToList();
                db.Tickets.RemoveRange(tickets);

                //Sterge evenimentul
                db.Events.Remove(entity);
                db.SaveChanges();
            }
        }

        internal void DeleteTicket(int id)
        {
            using (var db = new EventContext())
            {
                var booking = db.Tickets.FirstOrDefault(p => p.Id == id);
                var bEvent = db.Events.FirstOrDefault(e => e.Id == booking.EventId);
                if (booking == null) return;
                if (bEvent != null)
                {
                    bEvent.TicketsLeft += booking.Quantity;
                    db.Entry(bEvent).State = EntityState.Modified;
                }
                db.Tickets.Remove(booking);
                db.SaveChanges();
            }
        }
        internal void DeleteTableReservation(int id)
        {
            using (var db = new TableReservationContext())
            {
                var reservation = db.Reservations.FirstOrDefault(p => p.Id == id);
                if (reservation != null)
                {
                    db.Reservations.Remove(reservation);
                    db.SaveChanges();
                }
            }
        }
        //Bar
        internal List<PhotoBar> GetBarsPhoto()
        {
            List<BarDbTable> context;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BarDbTable, PhotoBar>()).CreateMapper();
            using (var db = new BarContext())
            {
                context = db.Bars.ToList();
            }
            return mapper.Map<List<PhotoBar>>(context);
        }
        internal UResponse AddBarEntity(PhotoBar photo)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoBar, BarDbTable>()).CreateMapper();
            BarDbTable context = mapper.Map<BarDbTable>(photo);

            context.Date = DateTime.Now;
            using (var db = new BarContext())
            {
                db.Bars.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
    }
}
