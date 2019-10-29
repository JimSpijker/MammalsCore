using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Models;

namespace DAL.Context.Interfaces
{
    public interface IGameContext
    {
        DataSet GetGame(string gameName);
        Game AddGame(Game game);
    }
}
