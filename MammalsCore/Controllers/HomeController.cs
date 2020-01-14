using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MammalsCore.Models;
using Logic.Interfaces;

namespace MammalsCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameContainerLogic gameContainerLogic;

        public HomeController(IGameContainerLogic gameContainerLogic)
        {
            this.gameContainerLogic = gameContainerLogic;
        }

        public IActionResult Index()
        {
            return View(gameContainerLogic.GetNewGames(5));
        }

        public IActionResult AZ()
        {
            return View(gameContainerLogic.GetAllGames());
        }

    }
}
