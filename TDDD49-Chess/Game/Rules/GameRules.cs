using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class GameRules : IGameRules
    {
        private IMovementRule[] _movementRules;
        private IGameStateRule[] _gameStateRules;

        public GameRules()
        {

        }

        public void Initialize()
        {
            _movementRules = new IMovementRule[6];
            _movementRules[Pieces.KING] = new KingMovementRule();
            _movementRules[Pieces.QUEEN] = new QueenMovementRule();
            _movementRules[Pieces.BISHOP] = new BishopMovementRule();
            _movementRules[Pieces.KNIGHT] = new KnightMovementRule();
            _movementRules[Pieces.ROOK] = new RookMovementRule();
            _movementRules[Pieces.PAWN] = new PawnMovementRule();

            _gameStateRules = new IGameStateRule[3];
        }

        public Boolean IsGameState(Board board, int state, int color)
        {
            if (!GameStateRule.Exists(state))
                throw new Exception("IsGameState failed. The Specified state does not exist.");
            return _gameStateRules[state].IsTrue(board, color);
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
