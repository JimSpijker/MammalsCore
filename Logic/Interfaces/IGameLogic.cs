﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    interface IGameLogic
    {
        Game GetGame(string gameName);

    }
}
