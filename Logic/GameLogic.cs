using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logic
{
    public class GameLogic : IGameLogic
    {
        private readonly IGameReviewRepository reviewRepository;

        public GameLogic(IGameReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public bool AddReview(Review review)
        {
            if (ReviewExists(review))
            {
                return false;
            }
            return reviewRepository.AddReview(review);
        }

        public bool DeleteReview(Review review)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(Game game)
        {
            return reviewRepository.GetReviews(game);
        }

        public bool ReviewExists(Review review)
        {
            return reviewRepository.ReviewExists(review);
        }
    }
}
