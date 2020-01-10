using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Interfaces;
using MammalsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MammalsCore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameContainerLogic gameContainerLogic;
        private readonly IGameLogic gameLogic;
        private readonly IAdminLogic adminLogic;

        public GameController(IGameContainerLogic gameContainerLogic, IGameLogic gameLogic, IAdminLogic adminLogic)
        {
            this.gameContainerLogic = gameContainerLogic;
            this.gameLogic = gameLogic;
            this.adminLogic = adminLogic;
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Name of the game</param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Index(string id)
        {
            Game game = new Game();
            game = gameContainerLogic.GetGame(id);
            game.Reviews = gameLogic.GetReviews(game);
            if (gameLogic.ReviewExists(new Review(){ UserId = 1, Game = game }))
            {
                ViewBag.ReviewExists = "true";
            }
            int totalScore = 0;
            if (game.Reviews.Count != 0)
            {
                foreach (Review review in game.Reviews)
                {
                    totalScore += review.Score;
                }

                game.Score = Convert.ToInt32(totalScore / game.Reviews.Count);
            }
            return View(game);
        }

        public ActionResult Create(GameViewModel gameViewModel)
        {
            return View(gameViewModel);
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            GameViewModel gameViewModel = new GameViewModel()
            {
                Game = game
            };
            if (game.Name == null || game.Name == "" || game.Description == null || game.Description == "")
            {
                gameViewModel.ErrorMessage = "Please fill in the required fields";
                return View();
            }
            if (adminLogic.AddGame(game))
            {
                return RedirectToAction("Index", new {id = game.Name});
            }
            else
            {
                gameViewModel.ErrorMessage = "Game already exists";
                return View(gameViewModel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Search query</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Search(string id)
        {
            if (id == null || id == "")
            {
                return View(new List<Game>());
            }
            return View(gameContainerLogic.SearchGames(id));
        }


    }
}