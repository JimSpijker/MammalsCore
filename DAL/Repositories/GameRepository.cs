using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Models;
using Logic.RepositoryInterfaces;
using DAL.Context.Interfaces;

namespace DAL.Repositories
{
    public class GameRepository : IGameContainerGameRepository, IAdminGameRepository
    {
        private readonly IGameContext context;

        public GameRepository(IGameContext context)
        {
            this.context = context;
        }

        public bool AddGame(Game game)
        {
            return context.AddGame(game);
        }

        public void DeleteGame(Game game)
        {
            context.DeleteGame(game);
        }

        public bool GameExists(string gameName)
        {
            return context.GameAlreadyExists(gameName);
        }

        public List<Game> GetAllGames()
        {
            return context.GetAllGames();
        }

        public Game GetGame(string gameName)
        {
            return context.GetGame(gameName);
        }

        public List<Game> GetNewGames(int amount)
        {
            return context.GetNewGames(amount);
        }

        public List<Game> GetPopulairGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetTopGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> SearchGames(string searchQuery)
        {
            return context.SearchGames(searchQuery);
        }
    }
}
