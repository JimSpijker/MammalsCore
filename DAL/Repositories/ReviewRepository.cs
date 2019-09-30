using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Context;
using DAL.Context.Interfaces;

namespace DAL.Repositories
{
    class ReviewRepository : IReviewContext
    {
        private readonly ReviewContext context;

        public ReviewRepository(ReviewContext context)
        {
            this.context = context;
        }

        public bool UpdateReview(Review changedReview)
        {
            return context.UpdateReview(changedReview);
        }
    }
}
