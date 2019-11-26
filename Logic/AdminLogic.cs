﻿using Logic.Interfaces;
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
            if (gameRepository.GameAlreadyExists(game.Name))
            {
                return false;
            }
            return gameRepository.AddGame(game);
        }

        public void DeleteGame(Game game)
        {
            gameRepository.DeleteGame(game);
        }

        public bool GameAlreadyExists(string gameName)
        {
            return gameRepository.GameAlreadyExists(gameName);
        }
    }
}
