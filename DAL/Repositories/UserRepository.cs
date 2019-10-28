using DAL.Context;
using DAL.Context.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IUserContext
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        

        public bool ChangePassword(User updatedUser)
        {
            return context.ChangePassword(updatedUser);
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
