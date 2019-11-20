using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IGameContainerLogic
    {
        Game GetGame(string gameName);
        List<Game> SearchGames(string searchQuery);
        List<Game> GetPopulairGames();
        List<Game> GetAllGames();
        List<Game> GetTopGames();

    }
}
