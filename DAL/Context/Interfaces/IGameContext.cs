using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Models;

namespace DAL.Context.Interfaces
{
    public interface IGameContext
    {
        Game GetGame(string gameName);
        bool AddGame(Game game);
        void DeleteGame(Game game);
        List<Game> SearchGames(string searchQuery);
        bool GameAlreadyExists(string gameName);
        List<Game> GetAllGames();
        List<Game> GetNewGames(int amount);
    }
}
