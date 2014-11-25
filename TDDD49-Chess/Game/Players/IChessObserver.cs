using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.Game.Players
{
    /// <summary>
    /// If i ever want to add flags to the game updated.
    /// </summary>
    public class GameUpdatedArgs
    {
        private Move move;
        private int _turn_color;

        public GameUpdatedArgs(Move move, int _turn_color)
        {
            // TODO: Complete member initialization
            this.move = move;
            this._turn_color = _turn_color;
        }

    }

    public interface IChessObserver : IReadOnlyChessEngine
    {
        /// <summary>
        /// Registers this object as an observer in the engine.
        /// This makes the engine notify the observer whenever anything changes.
        /// Returns true if it was sucessfully added.
        /// </summary>
        /// <returns></returns>
        Boolean RegisterAsObserver();
        Boolean Unregister();

        /// <summary>
        /// A method to be implemented by the observers.
        /// </summary>
        /// <param name="args"></param>
        void GameUpdated(GameUpdatedArgs args);
    }
}
