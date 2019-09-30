using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Admin : User
    {
        public Admin(int id, string name, string email, string password) : base(id, name, email, password)
        {
        }
    }
}
