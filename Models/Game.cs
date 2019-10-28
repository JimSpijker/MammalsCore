using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Game
    {
        public Game(int id, string name, string description, List<Review> reviews)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.reviews = reviews;
        }

        private int id;
        private string name;
        private string description;
        private List<Review> reviews;
        private int score;

        public int Score
        {
            get => score;
            set => score = value;
        }

        public List<Review> Reviews
        {
            get => reviews;
            set => reviews = value;
        }

        public Game(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }


        public Game() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
