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
            _gameStateRules[GameStateRule.DRAW] = new DrawGameStateRule();
            _gameStateRules[GameStateRule.WHITE_WON] = new ColorWonGameStateRule(Color.WHITE);
            _gameStateRules[GameStateRule.BLACK_WON] = new ColorWonGameStateRule(Color.BLACK);
        }

        public Boolean IsGameState(int state, Board board)
        {
            if (!GameStateRule.Exists(state))
                throw new Exception("IsGameState failed. The Specified state does not exist.");
            return _gameStateRules[state].IsTrue(board);
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
