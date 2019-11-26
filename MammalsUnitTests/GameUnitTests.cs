﻿using DAL.Context;
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
            adminLogic.AddGame(game);
            bool result = gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            adminLogic.DeleteGame(game);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddReview_ReviewExists()
        {
            adminLogic.AddGame(game);
            gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            bool result = gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            adminLogic.DeleteGame(game);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "DatabaseError")]
        public void AddReview_EmptyReview()
        {
            bool result = gameLogic.AddReview(new Review(0, null, null, 0));
        }

        //ReviewExists

        [TestMethod]
        public void ReviewExists_True()
        {
            adminLogic.AddGame(game);
            gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            bool result = gameLogic.ReviewExists(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            adminLogic.DeleteGame(game);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ReviewExists_False()
        {
            adminLogic.AddGame(game);
            gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            bool result = gameLogic.ReviewExists(new Review(2, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            adminLogic.DeleteGame(game);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "DatabaseError")]
        public void ReviewExists_EmptyReview()
        {
            bool result = gameLogic.ReviewExists(new Review(0, null, null, 0));
        }

        //GetReviews

        [TestMethod]
        public void GetReviews_OneReview()
        {
            adminLogic.AddGame(game);
            gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            int result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            adminLogic.DeleteGame(game);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetReviews_MultipleReviews()
        {
            adminLogic.AddGame(game);
            gameLogic.AddReview(new Review(1, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            gameLogic.AddReview(new Review(2, gameContainerLogic.GetGame(game.Name), "Review1", 1));
            int result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            adminLogic.DeleteGame(game);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetReviews_NoReviews()
        {
            adminLogic.AddGame(game);
            int result = gameLogic.GetReviews(gameContainerLogic.GetGame(game.Name)).Count;
            adminLogic.DeleteGame(game);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetReviews_EmptyGame()
        {
            int result = gameLogic.GetReviews(new Game(0, null, null)).Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "DatabaseError")]
        public void GetReviews_NullGame()
        {
            gameLogic.GetReviews(null);
        }
    }
}
