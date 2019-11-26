using DAL.Context;
using DAL.Repositories;
using Logic;
using Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;

namespace MammalsUnitTests
{
    [TestClass]
    public class GameContainerUnitTests
    {
        private readonly IGameContainerLogic gameContainerLogic;
        private readonly IAdminLogic adminLogic;

        public GameContainerUnitTests()
        {
            adminLogic = new AdminLogic(new GameRepository(new GameContext()));
            gameContainerLogic = new GameContainerLogic(new GameRepository(new GameContext()));
            games.Add(game1);
            games.Add(game2);
            games.Add(game3);
            games.Add(game4);
            games.Add(game5);
            games.Add(game6);
        }

        private Game game1 = new Game("Test1", "Test1");
        private Game game2 = new Game("Test2", "Test2");
        private Game game3 = new Game("Test3", "Test3");
        private Game game4 = new Game("Test4", "Test4");
        private Game game5 = new Game("Test5", "Test5");
        private Game game6 = new Game("Test6", "Test6");
        private List<Game> games = new List<Game>();

        public void AddGames()
        { 
            foreach (Game game in games)
            {
                adminLogic.AddGame(game);
            }
        }

        public void DeleteGames()
        {
            foreach (Game game in games)
            {
                adminLogic.DeleteGame(game);
            }
        }

        //GetAllGames

        [TestMethod]
        public void GetAllGames_Succes()
        {
            AddGames();
            int result = gameContainerLogic.GetAllGames().Count;
            DeleteGames();
            Assert.AreEqual(result, games.Count);
        }

        //GetGame

        [TestMethod]
        public void GetGame_Succes()
        {
            AddGames();
            string result = gameContainerLogic.GetGame(game1.Name).Name;
            DeleteGames();
            Assert.AreEqual(result, game1.Name);
        }

        [TestMethod]
        public void GetGame_Misspelling()
        {
            AddGames();
            string result = gameContainerLogic.GetGame("Misspelled").Name;
            DeleteGames();
            Assert.AreNotEqual(result, game1.Name);
        }

        [TestMethod]
        public void GetGame_EmptyString()
        {
            AddGames();
            string result = gameContainerLogic.GetGame("").Name;
            DeleteGames();
            Assert.AreNotEqual(result, game1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "DatabaseError")]
        public void GetGame_NullString()
        {
            AddGames();
            string result = gameContainerLogic.GetGame(null).Name;
            DeleteGames();
        }

        //GetNewGames

        [TestMethod]
        public void GetNewGames_Succes()
        {
            AddGames();
            int result = gameContainerLogic.GetNewGames(5).Count;
            DeleteGames();
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GetNewGames_LessThanGivenNumber()
        {
            AddGames();
            int result = gameContainerLogic.GetNewGames(7).Count;
            DeleteGames();
            Assert.AreEqual(games.Count, result);
        }

        [TestMethod]
        public void GetNewGames_Zero()
        {
            AddGames();
            int result = gameContainerLogic.GetNewGames(0).Count;
            DeleteGames();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "DatabaseError")]
        public void GetNewGames_NegativeNumber()
        {
            AddGames();
            int result = gameContainerLogic.GetNewGames(-1).Count;
            DeleteGames();
        }

        //SearchGames

        [TestMethod]
        public void SearchGames_OneResult()
        {
            AddGames();
            int result = gameContainerLogic.SearchGames(game1.Name).Count;
            DeleteGames();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SearchGames_MultipleResults()
        {
            AddGames();
            int result = gameContainerLogic.SearchGames("Test").Count;
            DeleteGames();
            Assert.AreEqual(games.Count, result);
        }

        [TestMethod]
        public void SearchGames_NoResults()
        {
            AddGames();
            int result = gameContainerLogic.SearchGames("NonExistingGame").Count;
            DeleteGames();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SearchGames_EmptyString()
        {
            AddGames();
            int result = gameContainerLogic.SearchGames("").Count;
            DeleteGames();
            Assert.AreEqual(games.Count, result);
        }

        [TestMethod]
        public void SearchGames_NullString()
        {
            AddGames();
            int result = gameContainerLogic.SearchGames(null).Count;
            DeleteGames();
            Assert.AreEqual(0, result);
        }
    }
}
