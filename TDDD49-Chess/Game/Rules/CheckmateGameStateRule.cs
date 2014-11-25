using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class CheckmateGameStateRule : IGameStateRule
    {

        private IGameStateRule _checkRule;
        private IGameStateRule _stalemateRule;

        public CheckmateGameStateRule()
        {
            _checkRule = new CheckGameStateRule();
            _stalemateRule = new StalemateGameStateRule();
        }

        /// <summary>
        /// It's check mate iff
        /// The color is currently in check, and
        /// There is no possible move which removes check.
        /// 
        /// This can be translated to:
        /// 1) Color is in check
        /// 2) The board is stalemate (no position possible which doesn't put king in check)
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsTrue(Board board, int color)
        {
            if (color == Color.NONE)
                throw new Exception("Cannot check checkmate on no color");

            if (!_checkRule.IsTrue(board, color))
                return false;

            if (!_stalemateRule.IsTrue(board, color))
                return false;

            return true;
        }
    }
}
