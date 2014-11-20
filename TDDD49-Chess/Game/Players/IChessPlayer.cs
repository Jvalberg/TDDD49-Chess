using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Players
{
    public interface IChessPlayer : IChessObserver
    {
        /// <summary>
        /// Tries to regster this player as the specified color
        /// to the game engine.
        /// Returns true if it was successfully added.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        Boolean RegisterAsPlayer(int color);

        new IPlayerChessEngine ChessEngine { get; }
    }
}
