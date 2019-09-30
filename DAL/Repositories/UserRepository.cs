using DAL.Context;
using DAL.Context.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Repositories
{
    class UserRepository : IUserContext
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public bool AddReview(Review review)
        {
            return context.AddReview(review);
        }

        public bool ChangePassword(User updatedUser)
        {
            return context.ChangePassword(updatedUser);
        }

        public bool DeleteReview(Review review)
        {
            return context.DeleteReview(review);
        }

        public DataSet GetReviews(User user)
        {
            return context.GetReviews(user);
        }

        public DataSet Login(string name, string password)
        {
            return context.Login(name, password);
        }

        public bool Register(User user)
        {
            return context.Register(user);
        }
    }
}
