using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class CheckGameStateRule : IGameStateRule
    {
        private IMovementRules _movementRules;

        public CheckGameStateRule()
        {
            _movementRules = new MovementRules();
        }

        public bool IsTrue(Board board, int color)
        {
            if (color == Color.NONE)
                throw new Exception("Cannot check if color: \"NONE\" is in check.");

            var ownPieces = board.GetAllPieces(color);
            Point king = new Point(-1, -1);
            foreach(var piece in ownPieces)
            {
                if(board.Squares[piece.X, piece.Y].Piece == Pieces.KING)
                {
                    king = piece;
                }
            }
            if (king.X == -1 && king.Y == -1)
                throw new Exception("Cannot check if color is in check if they don't have king. The game is messed up.");

            var oppositionColor = color == Color.BLACK ? Color.WHITE : Color.BLACK;
            var oppositionPieces = board.GetAllPieces(oppositionColor);
            foreach(var piece in oppositionPieces)
            {
                var validMoves = _movementRules.ValidMoves(board, piece);
                if(validMoves.Contains(king))
                    return true;
            }

            return false;
        }
    }
}
