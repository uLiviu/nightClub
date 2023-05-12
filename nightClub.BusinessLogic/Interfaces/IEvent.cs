using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IEvent
    {
        List<EventModel> GetAll();
        EventModel GetById(int id);
        UResponse Add(EventModel newPhoto);
        UResponse Update(Event data);
        void Delete(int id);
    }
}
