using DAL.Context;
using DAL.Repositories;
using Logic;
using Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MammalsUnitTests
{
    [TestClass]
    public class GameUnitTests
    {
        private readonly IGameLogic gameLogic;
        private readonly IAdminLogic adminLogic;
        private readonly IGameContainerLogic gameContainerLogic;
        public GameUnitTests()
        {
            gameLogic = new GameLogic(new ReviewRepository(new ReviewContext()));
            adminLogic = new AdminLogic(new GameRepository(new GameContext()));
            gameContainerLogic = new GameContainerLogic(new GameRepository(new GameContext()));
        }

        private Game game = new Game("gameName", "gameDescription");

        //AddReview

        [TestMethod]
        public void AddReview_Succes()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                result = gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddReview_ReviewExists()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                result = gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void AddReview_EmptyReview()
        {
            bool result = gameLogic.AddReview(new Review(0, null, null, 0));
        }

        //ReviewExists

        [TestMethod]
        public void ReviewExists_True()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                result = gameLogic.ReviewExists(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ReviewExists_False()
        {
            bool result;
            adminLogic.AddGame(game);
            try
            {
                gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                result = gameLogic.ReviewExists(new Review(2, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void ReviewExists_EmptyReview()
        {
            bool result = gameLogic.ReviewExists(new Review(0, null, null, 0));
        }

        //GetReviews

        [TestMethod]
        public void GetReviews_OneReview()
        {
            int result;
            adminLogic.AddGame(game);
            try
            {
                gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetReviews_MultipleReviews()
        {
            int result;
            adminLogic.AddGame(game);
            try
            {
                gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                gameLogic.AddReview(new Review(2, gameContainerLogic.GetGame(game.Name), "Review1", 1));
                result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetReviews_NoReviews()
        {
            int result;
            adminLogic.AddGame(game);
            try
            {
                result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            }
            finally
            {
                adminLogic.DeleteGame(game);
            }
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetReviews_EmptyGame()
        {
            int result = gameLogic.GetReviews(new Game(0, null, null)).Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Had trouble connecting to server")]
        public void GetReviews_NullGame()
        {
            gameLogic.GetReviews(null);
        }
    }
}
