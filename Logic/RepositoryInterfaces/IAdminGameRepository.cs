using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.RepositoryInterfaces
{
    public interface IAdminGameRepository
    {
        Game AddGame(Game game);
    }
}
