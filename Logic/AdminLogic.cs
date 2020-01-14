using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AdminLogic : IAdminLogic
    {
        private readonly IAdminGameRepository gameRepository;

        public AdminLogic(IAdminGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public bool AddGame(Game game)
        {
            if (game == null || game.Name == null || game.Name == "" || game.Description == null || game.Description == "")
            {
                throw new Exception("The given game was empty");
            }
            if (gameRepository.GameExists(game.Name))
            {
                return false;
            }
            return gameRepository.AddGame(game);
        }

        public void DeleteGame(Game game)
        {
            if (game == null || game.Name == null || game.Name == "")
            {
                throw new Exception("The given game was empty");
            }
            gameRepository.DeleteGame(game);
        }

        public bool GameAlreadyExists(string gameName)
        {
            if (gameName == null || gameName == "")
            {
                throw new Exception("The given game was empty");
            }
            return gameRepository.GameExists(gameName);
        }
    }
}
