using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IAdminGameRepository
    {
        bool AddGame(Game game);
        bool GameAlreadyExists(string gameName);
    }
}
