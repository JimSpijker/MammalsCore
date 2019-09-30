using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Context.Interfaces
{
    public interface IGameContext
    {
        DataSet GetGame(string gameName);
    }
}
