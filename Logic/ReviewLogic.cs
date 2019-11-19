using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;

namespace Logic
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly IReviewReviewRepository reviewRepository;

        public ReviewLogic(IReviewReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public void UpdateReview(Review oldReview, Review newReview)
        {
            throw new NotImplementedException();
        }
    }
}
