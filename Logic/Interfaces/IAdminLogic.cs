using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IAdminLogic
    {
        bool AddGame(Game game);
        void DeleteGame(Game game);
        bool GameAlreadyExists(string gameName);
    }
}
