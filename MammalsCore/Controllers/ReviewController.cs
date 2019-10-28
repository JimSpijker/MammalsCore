using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context.Interfaces;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MammalsCore.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IGameContext gameContext;
        private readonly IReviewContext reviewContext;

        public ReviewController(IGameContext gameContext, IReviewContext reviewContext)
        {
            this.gameContext = gameContext;
            this.reviewContext = reviewContext;
        }
        public IActionResult Index(Review review)
        {
            return View(review);
        }
        public IActionResult CreateReview(string gameName)
        {
            GameLogic gameLogic = new GameLogic(gameContext);
            Review review = new Review(0, 0, gameLogic.GetGame(gameName), null, 0);
            return View(review);
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            ReviewLogic reviewLogic = new ReviewLogic(reviewContext);
            GameLogic gameLogic = new GameLogic(gameContext);
            review.UserId = 1;
            review.Game = gameLogic.GetGame(review.Game.Name);
            if (reviewLogic.AddReview(review))
            {
                return RedirectToAction("Index", review);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}