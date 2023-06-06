using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Bar;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class BarBL : ContentApi, IBar
    {
        public List<PhotoBar> GetBars()
        {
            return GetBarsPhoto();
        }
        public PhotoBar GetBarById(int id)
        {
            return GetBarPhotoById(id);
        }

        public UResponse Add(PhotoBar photo)
        {
            return AddBarEntity(photo);
        }

        public UResponse Update(PhotoBar data)
        {
            return UpdateBarPhoto(data);
        }

        public void DeleteBar(int id)
        {
            DeleteBarPhoto(id);
        }

        public List<PhotoBar> GetBarsByCategory()
        {
            return GetBarsPhotoByCategory();
        }

        public List<PhotoBar> GetBarsByPrice()
        {
            return GetBarsPhotoByPrice();
        }

        public List<PhotoBar> GetBarsByAlcohol()
        {
            return GetBarsPhotoByAlcohol();
        }
        public List<PhotoBar> SearchProducts(string search)
        {
            return SearchBarProducts(search);
        }
    }
}

