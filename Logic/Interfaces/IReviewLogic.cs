using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Logic.Interfaces
{
    public interface IReviewLogic
    {
        bool AddReview(Review review);
        List<Review> GetReviews(Game game);
    }
}
