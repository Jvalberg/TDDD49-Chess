using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.AI
{
    public interface IAIChessPlayer
    {
        /// <summary>
        /// Adds an AI to the current chess game
        /// The AI will either just pick a color
        /// or take the color which is left
        /// 
        /// The AI will then handle itself and play 
        /// until the game is over.
        /// </summary>
        void AddAI();

        /// <summary>
        /// Break down and remove this AI 
        /// from the game.
        /// </summary>
        void Dispose();

        bool IsActive();
    }
}
