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

        [HttpGet]
        public ActionResult Index(string id)
        {
            Game game = new Game();
            game = gameContainerLogic.GetGame(id);
            game.Reviews = gameLogic.GetReviews(game);
            int n = 0;
            if (game.Reviews.Count != 0)
            {
                foreach (Review review in game.Reviews)
                {
                    n += review.Score;
                }

                game.Score = Convert.ToInt32(n / game.Reviews.Count);
            }
            return View(game);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (adminLogic.AddGame(game) != null)
            {
                return RedirectToAction("Index", new {id = game.Name});
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Search(string id)
        {
            return View(gameContainerLogic.SearchGames(id));
        }


    }
}