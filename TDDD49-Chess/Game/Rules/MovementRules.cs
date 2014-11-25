using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class MovementRules : IMovementRules
    {
        private IMovementRule[] _movementRules;

        public MovementRules()
        {
            _movementRules = new IMovementRule[6];
            _movementRules[Pieces.KING] = new KingMovementRule();
            _movementRules[Pieces.QUEEN] = new QueenMovementRule();
            _movementRules[Pieces.BISHOP] = new BishopMovementRule();
            _movementRules[Pieces.KNIGHT] = new KnightMovementRule();
            _movementRules[Pieces.ROOK] = new RookMovementRule();
            _movementRules[Pieces.PAWN] = new PawnMovementRule();
        }

        public IList<Point> ValidMoves(Board board, Point coordinates)
        {
            int piece = board.Squares[coordinates.X, coordinates.Y].Piece;
            if (Pieces.IsNotPiece(piece) ||
                piece < 0 || piece >= _movementRules.Length)
                return new List<Point>();

            return _movementRules[piece].ValidMoves(board, coordinates);
        }

    }
}
