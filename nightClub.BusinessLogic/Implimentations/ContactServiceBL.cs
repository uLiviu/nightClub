using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Contact;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class ContactServiceBL : ContentApi, IContactService
    {
        public void AddReview(ReviewModel review)
        {
            AddNewReview(review);
        }

        public List<ReviewModel> GetReviews()
        {
            return GetReviewList();
        }
    }
}
