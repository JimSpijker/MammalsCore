using DAL.Context;
using DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Models;

namespace DAL.Repositories
{
    public class GameRepository : IGameContext
    {
        private readonly IGameContext context;

        public GameRepository(IGameContext context)
        {
            this.context = context;
        }
        public DataSet GetGame(string gameName)
        {
            return context.GetGame(gameName);
        }

        public Game AddGame(Game game)
        {
            return context.AddGame(game);
        }

        public List<Game> SearchGames(string searchTerm)
        {
            return context.SearchGames(searchTerm);
        }
    }
}
