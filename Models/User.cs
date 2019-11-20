using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Constructors
        public User(int id, string name, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}
