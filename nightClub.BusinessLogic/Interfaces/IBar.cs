using nightClub.Domain.Entities.Bar;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IBar
    {
        List<PhotoBar> GetBars();
        PhotoBar GetBarById(int id);
        UResponse Add(PhotoBar newPhoto);
        UResponse Update(PhotoBar data);
        void DeleteBar(int id);
        List<PhotoBar> GetBarsByCategory();
        List<PhotoBar> GetBarsByPrice();
        List<PhotoBar> GetBarsByAlcohol();
        List<PhotoBar> SearchProducts(string search);
    }
}
