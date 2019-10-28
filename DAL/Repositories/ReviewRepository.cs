using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Context;
using DAL.Context.Interfaces;

namespace DAL.Repositories
{
    public class ReviewRepository : IReviewContext
    {
        private readonly IReviewContext context;

        public ReviewRepository(IReviewContext context)
        {
            this.context = context;
        }

        public bool UpdateReview(Review changedReview)
        {
            return context.UpdateReview(changedReview);
        }

        public bool DeleteReview(Review review)
        {
            return context.DeleteReview(review);
        }

        public List<Review> GetReviews(User user)
        {
            return context.GetReviews(user);
        }

        public List<Review> GetReviews(Game game)
        {
            return context.GetReviews(game);
        }

        public bool AddReview(Review review)
        {
            return context.AddReview(review);
        }
    }
}
