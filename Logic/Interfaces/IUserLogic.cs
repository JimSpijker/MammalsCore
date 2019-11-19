using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        bool UpdateUser(User newUser);
        List<Review> GetReviews(User user);
    }
}
