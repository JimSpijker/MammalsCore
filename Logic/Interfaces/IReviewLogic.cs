﻿using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Logic.Interfaces
{
    public interface IReviewLogic
    {
        void UpdateReview(Review oldReview, Review newReview);
    }
}
