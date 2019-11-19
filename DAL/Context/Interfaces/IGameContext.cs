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
        Game AddGame(Game game);
        List<Game> SearchGames(string searchQuery);
    }
}
