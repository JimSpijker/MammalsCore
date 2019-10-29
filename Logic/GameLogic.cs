using DAL.Context.Interfaces;
using DAL.Repositories;
using Logic.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logic
{
    public class GameLogic : IGameLogic
    {
        private readonly GameRepository repository;

        public GameLogic(IGameContext context)
        {
            repository = new GameRepository(context);
        }

        public Game GetGame(string gameName)
        {
            Game game = new Game(0, null, null);
            DataSet dataSet = new DataSet();
            dataSet = repository.GetGame(gameName);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
            }
            return game;
        }

        public Game AddGame(Game game)
        {
            return repository.AddGame(game);
        }
    }
}
