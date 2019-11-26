using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Game
    {
        //Properties
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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
        public Game(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Game() { }
    }
}
