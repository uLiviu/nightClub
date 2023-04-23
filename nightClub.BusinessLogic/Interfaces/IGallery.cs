using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.User;

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
