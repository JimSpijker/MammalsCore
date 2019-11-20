using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IGameLogic
    {
        bool AddReview(Review review);
        bool DeleteReview(Review review);
        List<Review> GetReviews(Game game);
        bool ReviewExists(Review review);

    }
}
