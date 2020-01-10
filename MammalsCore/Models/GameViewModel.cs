using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MammalsCore.Models
{
    public class GameViewModel
    {
        public string ErrorMessage { get; set; }
        public Game Game { get; set; }


        public GameViewModel() { }
    }
}
