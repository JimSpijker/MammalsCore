using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Context.Interfaces
{
    public interface IReviewContext
    {
        bool UpdateReview(Review changedReview);
        List<Review> GetReviews(User user);
        List<Review> GetReviews(Game game);
        bool AddReview(Review review);
        bool DeleteReview(Review review);
        bool ReviewExists(Review review);

    }
}

