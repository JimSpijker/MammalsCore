using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Context.Interfaces
{
    interface IUserContext
    {
        bool Register(User user);
        DataSet Login(string name, string password);
        bool ChangePassword(User updatedUser);
        DataSet GetReviews(User user);
        bool AddReview(Review review);
        bool DeleteReview(Review review);
    }
}
