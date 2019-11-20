using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MammalsCore.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IGameContainerLogic gameContainerLogic;
        private readonly IGameLogic gameLogic;

        public ReviewController(IGameContainerLogic gameContainerLogic, IGameLogic gameLogic)
        {
            this.gameContainerLogic = gameContainerLogic;
            this.gameLogic = gameLogic;
        }
        public IActionResult Index(Review review)
        {
            return View(review);
        }
        public IActionResult Create(string gameName)
        {
            Review review = new Review(0, 0, gameContainerLogic.GetGame(gameName), null, 0);
            return View(review);
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            review.UserId = 1;
            review.Game = gameContainerLogic.GetGame(review.Game.Name);
            if (gameLogic.AddReview(review))
            {
                return RedirectToAction("Index", "Game", new {id = review.Game.Name});
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}