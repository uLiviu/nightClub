using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.Implimentations
{
    public class EventBL : ContentApi, IEvent
    {
        public List<EventModel> GetAll()
        {
            return GetAllEvents();
        }

        public EventModel GetById(int id)
        {
            return GetEventById(id);
        }

        public UResponse Add(EventModel newEvent)
        {
            return AddEvent(newEvent);
        }

        public UResponse Update(Event data)
        {
            return UpdateEvent(data);
        }

        public void Delete(int id)
        {
            DeleteEvent(id);
        }
    }
}