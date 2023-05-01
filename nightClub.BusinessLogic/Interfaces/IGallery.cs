using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IGallery
    {
        List<PhotoModel> GetAll();
        PhotoModel GetById(int id);

        UResponse Add(PhotoModel newPhoto);
        UResponse Update(PhotoModel data);
        void Delete(int id);
    }
}
