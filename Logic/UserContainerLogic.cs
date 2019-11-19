using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserContainerLogic : IUserContainerLogic
    {
        private readonly IUserContainerUserRepository userRepository;

        public UserContainerLogic(IUserContainerUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
