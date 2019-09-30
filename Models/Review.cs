using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review
    {
        private int id;
        private User user;
        private Game game;
        private string description;
        private int score;

        public Review(int id, User user, Game game, string description, int score)
        {
            this.id = id;
            this.user = user;
            this.game = game;
            this.description = description;
            this.score = score;
        }

        public int Id { get => id;}
        public User User { get => user;}
        public Game Game { get => game;}
        public string Description { get => description;}
        public int Score { get => score;}
    }
}
