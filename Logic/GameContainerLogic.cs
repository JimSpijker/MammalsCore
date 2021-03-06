﻿using Logic.Exceptions;
using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class GameContainerLogic : IGameContainerLogic
    {
        private readonly IGameContainerGameRepository gameRepository;

        public GameContainerLogic(IGameContainerGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public List<Game> GetAllGames()
        {
            return gameRepository.GetAllGames();
        }

        public Game GetGame(string gameName)
        {
            if (gameName == null || gameName == "")
            {
                throw new EmptyOrNullException("The given game was empty");
            }
            return gameRepository.GetGame(gameName);
        }

        public List<Game> GetNewGames(int amount)
        {
            if (amount <= 0)
            {
                throw new EmptyOrNullException("The given amount was or lower than 0");
            }
            return gameRepository.GetNewGames(amount);
        }

        public List<Game> GetPopulairGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetTopGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> SearchGames(string searchTerm)
        {
            if (searchTerm == null)
            {
                return new List<Game>();
            }
            return gameRepository.SearchGames(searchTerm);
        }
    }
}
