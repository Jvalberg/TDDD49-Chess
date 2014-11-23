using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public interface IGameRules : IMovementRule
    {
        Boolean IsGameState(Board board, int state, int color);
    }
}
