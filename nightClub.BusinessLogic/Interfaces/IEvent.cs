using nightClub.Domain.Entities.Event;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IEvent
    {
        List<EventModel> GetAll();
        EventModel GetById(int id);
        UResponse Add(EventModel newPhoto);
        UResponse Update(EventModel data);
        void Delete(int id);
    }
}
