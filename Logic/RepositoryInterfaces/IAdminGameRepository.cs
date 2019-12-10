using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IAdminGameRepository
    {
        bool AddGame(Game game);
        void DeleteGame(Game game);
        bool GameExists(string gameName);
    }
}
