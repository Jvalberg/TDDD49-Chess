using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public interface IGameRules
    {
        Boolean IsGameState(Board board, int state, int color);
        IMovementRules MovementRules { get; }
        IList<Point> FilterCheckMoves(Board board, Point point, IList<Point> moves);
    }
}
