using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public interface IMovementRule
    {
        /// <summary>
        /// Returns all valid moves for the specified piece on the
        /// given location.
        /// NOTE: This does not take into account other rules like "check" and such.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        IList<Point> ValidMoves(Board board, Point coordinates);
    }
}
