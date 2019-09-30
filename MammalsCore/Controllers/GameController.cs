using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace MammalsCore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameContext gameContext;

        public GameController(IGameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        public ActionResult Index(string id)
        {
            GameLogic gameLogic = new GameLogic(gameContext);
            return View(gameLogic.GetGame(id));
        }
    }
}