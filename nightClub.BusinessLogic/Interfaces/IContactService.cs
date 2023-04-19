using nightClub.Domain.Entities.Contact;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface IContactService
    {
        void AddReview(ReviewModel review);
        List<ReviewModel> GetReviews();
    }
}
