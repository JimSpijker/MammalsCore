using Logic.Exceptions;
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
            if (review == null || review.Description == null || review.Description == "" || review.Game == null)
            {
                throw new EmptyOrNullException("The given review was empty");
            }
            if (ReviewExists(review))
            {
                return false;
            }
            return reviewRepository.AddReview(review);
        }

        public bool DeleteReview(Review review)
        {
            if (review == null || review.Id == 0)
            {
                throw new EmptyOrNullException("The given review was empty");
            }
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(Game game)
        {
            if (game == null || game.Name == null || game.Name == "")
            {
                throw new EmptyOrNullException("The given game was empty");
            }
            return reviewRepository.GetReviews(game);
        }

        public bool ReviewExists(Review review)
        {
            if (review == null || review.UserId == 0 || review.Game == null)
            {
                throw new EmptyOrNullException("The given review was empty");
            }
            return reviewRepository.ReviewExists(review);
        }
    }
}
