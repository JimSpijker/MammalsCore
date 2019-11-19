using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IReviewReviewRepository
    {
        void UpdateReview(Review oldReview, Review newReview);
    }
}
