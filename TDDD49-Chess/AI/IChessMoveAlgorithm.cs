using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.AI
{
    public interface IChessMoveAlgorithm
    {
        Tuple<Point, Point> GetNextMove(Board board, int color);
    }
}
