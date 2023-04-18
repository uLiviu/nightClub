using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Contact;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IContactService
    {
        void AddReview(Review review);
        List<Review> GetReviews();
    }
}
    