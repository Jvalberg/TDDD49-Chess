using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class StalemateGameStateRule : IGameStateRule
    {

        private IMovementRules _movementRules;
        private IGameStateRule _checkRule;

        public StalemateGameStateRule()
        {
            _checkRule = new CheckGameStateRule();
            _movementRules = new MovementRules();
        }

        /// <summary>
        /// The specified color is the color whos turn it is
        /// If no move can be made by the color which is in turn
        /// then it is stalemate.
        /// Cannot make a move which puts the king in check.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsTrue(Board board, int color)
        {
            if (color == Color.NONE)
                throw new Exception("Has to be someones turn.");

            var ownPieces = board.GetAllPieces(color);
            var oppositionColor = color == Color.BLACK ? Color.WHITE : Color.BLACK;
            
            foreach(var piece in ownPieces)
            {
                var possibleMoves = _movementRules.ValidMoves(board, piece);
                foreach (var validMove in possibleMoves)
                {
                    Board copy = board.MakeMove(piece, validMove);
                    if (!_checkRule.IsTrue(copy, color))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
