using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Context;
using DAL.Context.Interfaces;
using Logic.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class ReviewRepository : IReviewReviewRepository, IGameReviewRepository, IUserReviewRepository
    {
        private readonly IReviewContext context;

        public ReviewRepository(IReviewContext context)
        {
            this.context = context;
        }

        public bool AddReview(Review review)
        {
            return context.AddReview(review);
        }

        public bool DeleteReview(Review review)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(Game game)
        {
            return context.GetReviews(game);
        }

        public List<Review> GetReviews(User user)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(Review review)
        {
            return context.ReviewExists(review);
        }

        public void UpdateReview(Review oldReview, Review newReview)
        {
            throw new NotImplementedException();
        }
    }
}
