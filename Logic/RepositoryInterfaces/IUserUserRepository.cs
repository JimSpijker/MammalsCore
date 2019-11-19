using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IUserUserRepository
    {
        bool UpdateUser(User newUser);
    }
}
