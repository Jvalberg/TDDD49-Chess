﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class KingMovementRule : IMovementRule
    {
        public IList<Point> ValidMoves(Board board, Point coordinates)
        {
            throw new NotImplementedException();
        }
    }
}