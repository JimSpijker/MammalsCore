using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Review
    {
        public int Id
        {
            get => id;
            set => id = value;
        }

        public int UserId
        {
            get => userId;
            set => userId = value;
        }

        public Game Game
        {
            get => game;
            set => game = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        private int id;
        private int userId;
        private Game game;
        private string description;
        private int score;

        public Review(int id, int userId, Game game, string description, int score)
        {
            this.id = id;
            this.userId = userId;
            this.game = game;
            this.description = description;
            this.score = score;
        }

        public Review()
        {
        }

    }
}
