using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IUserContainerLogic
    {
        bool Register(User user);
        User Login(string name, string password);
    }
}
