using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Logic;

namespace MammalsCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IGameContext gameContext;

        public UserController(IGameContext gameContext)
        {
            this.gameContext = gameContext;
        }
        

    }
}