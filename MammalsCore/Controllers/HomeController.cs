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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
