using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Repositories;
using Logic.Interfaces;
using Models;

namespace Logic
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly ReviewRepository repository;

        public ReviewLogic(IReviewContext context)
        {
            repository = new ReviewRepository(context);
        }
        public bool AddReview(Review review)
        {
            return repository.AddReview(review);
        }

        public List<Review> GetReviews(Game game)
        {
            return repository.GetReviews(game);
        }
    }
}
