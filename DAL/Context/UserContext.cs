using DAL.Context.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Context
{
    public class UserContext : IUserContext
    {
        private readonly Connection con;

        public UserContext()
        {
            con = new Connection();
        }
        

        public bool ChangePassword(User updatedUser)
        {
            throw new NotImplementedException();
        }

        public DataSet Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
