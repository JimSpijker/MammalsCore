using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review
    {
        //Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        public Game Game { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }

        //Constructors
        public Review(int id, int userId, Game game, string description, int score)
        {
            this.Id = id;
            this.UserId = userId;
            this.Game = game;
            this.Description = description;
            this.Score = score;
        }

        public Review(){}

    }
}
