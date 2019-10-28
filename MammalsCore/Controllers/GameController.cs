using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context.Interfaces;
using Logic;
using MammalsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MammalsCore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameContext gameContext;
        private readonly IReviewContext reviewContext;

        public GameController(IGameContext gameContext, IReviewContext reviewContext)
        {
            this.gameContext = gameContext;
            this.reviewContext = reviewContext;
        }

        public ActionResult Index(string id)
        {
            GameLogic gameLogic = new GameLogic(gameContext);
            ReviewLogic reviewLogic = new ReviewLogic(reviewContext);
            Game game = new Game();
            game = gameLogic.GetGame(id);
            game.Reviews = reviewLogic.GetReviews(game);
            int n = 0;
            foreach (Review review in game.Reviews)
            {
                n += review.Score;
            }
            game.Score = Convert.ToInt32(n / game.Reviews.Count);
            return View(game);

        }

        
    }
}