using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IGameContainerGameRepository
    {
        Game GetGame(string gameName);
        List<Game> SearchGames(string searchQuery);
        List<Game> GetPopulairGames();
        List<Game> GetAllGames();
        List<Game> GetTopGames();
    }
}
