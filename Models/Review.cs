using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Review
    {
        //Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
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

        public Review(int userId, Game game, string description, int score)
        {
            this.UserId = userId;
            this.Game = game;
            this.Description = description;
            this.Score = score;
        }

        public Review(){}

    }
}
