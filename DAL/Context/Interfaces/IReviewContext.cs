using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Context.Interfaces
{
    interface IReviewContext
    {
        bool UpdateReview(Review changedReview);

    }
}

