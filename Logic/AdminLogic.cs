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
        public Game AddGame(Game game)
        {
            return gameRepository.AddGame(game);
        }
    }
}
