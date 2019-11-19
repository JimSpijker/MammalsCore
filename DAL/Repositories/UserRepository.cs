using DAL.Context;
using DAL.Context.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IUserUserRepository, IUserContainerUserRepository
    {
        public User Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
