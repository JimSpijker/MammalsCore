using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IUserReviewRepository
    {
        List<Review> GetReviews(User user);
    }
}
