using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserReviewRepository reviewRepository;
        private readonly IUserUserRepository userRepository;

        public UserLogic(IUserReviewRepository reviewRepository, IUserUserRepository userRepository)
        {
            this.reviewRepository = reviewRepository;
            this.userRepository = userRepository;
        }
        public List<Review> GetReviews(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
