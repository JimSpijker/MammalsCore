using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Context.Interfaces
{
    public interface IUserContext
    {
        bool Register(User user);
        DataSet Login(string name, string password);
        bool ChangePassword(User updatedUser);
        
    }
}
