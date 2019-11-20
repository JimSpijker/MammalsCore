using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Game
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Review> Reviews { get; set; }
        public int Score { get; set; }

        //Constructors
        public Game(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Game() { }
    }
}
