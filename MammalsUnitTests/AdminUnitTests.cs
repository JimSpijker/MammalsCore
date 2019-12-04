using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Interfaces;
using Logic.RepositoryInterfaces;
using Models;
using Logic;
using DAL.Repositories;
using DAL.Context;
using System;

namespace MammalsUnitTests
{
    [TestClass]
    public class AdminUnitTests
    {
        private readonly IAdminLogic adminLogic;
        private readonly IGameContainerLogic gameContainerLogic;

        public AdminUnitTests()
        {
            adminLogic = new AdminLogic(new GameRepository(new GameContext()));
            gameContainerLogic = new GameContainerLogic(new GameRepository(new GameContext()));
        }

        private Game game = new Game("gameName", "gameDescription");

        //AddGame

        [TestMethod]
        public void AddGame_Succes()
        {
            bool result;
            try
            {
                result = adminLogic.AddGame(game);
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddGame_GameExists()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                result = adminLogic.AddGame(game);
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void AddGame_EmptyGame()
        {
            Game emptyGame = new Game(null, null);
            adminLogic.AddGame(emptyGame);
        }

        //GameAlreadyExists

        [TestMethod]
        public void GameAlreadyExists_Succes_True()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                result = adminLogic.GameAlreadyExists(game.Name);
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GameAlreadyExists_Succes_False()
        {
            bool result = adminLogic.GameAlreadyExists(game.Name);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GameAlreadyExists_EmptyString()
        {
            bool result = adminLogic.GameAlreadyExists("");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void GameAlreadyExists_NullString()
        {
            bool result = adminLogic.GameAlreadyExists(null);
        }

        //DeleteGame

        [TestMethod]
        public void DeleteGame_Succes()
        {
            adminLogic.AddGame(game);
            adminLogic.DeleteGame(game);
            Game result = gameContainerLogic.GetGame(game.Name);
            Assert.AreEqual(null, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void DeleteGame_EmptyGame()
        {
            adminLogic.DeleteGame(new Game(null, null));
        }
    }
}
