using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IUserContainerUserRepository
    {
        bool Register(User user);
        User Login(string name, string password);

    }
}
