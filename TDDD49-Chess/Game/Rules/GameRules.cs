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
        private IGameStateRule[] _gameStateRules;
        private IMovementRules _movementRules;

        public GameRules()
        {
            Initialize();
        }

        public void Initialize()
        {
            _movementRules = new MovementRules();

            _gameStateRules = new IGameStateRule[3];
            _gameStateRules[GameStateRule.STALEMATE] = new StalemateGameStateRule();
            _gameStateRules[GameStateRule.CHECK] = new CheckGameStateRule();
            _gameStateRules[GameStateRule.CHECKMATE] = new CheckmateGameStateRule();
        }

        public IMovementRules MovementRules
        {
            get { return _movementRules; }
        }

        public Boolean IsGameState(Board board, int state, int color)
        {
            if (!GameStateRule.Exists(state))
                throw new Exception("IsGameState failed. The Specified state does not exist.");
            return _gameStateRules[state].IsTrue(board, color);
        }


        public IList<Point> FilterCheckMoves(Board board, Point point, IList<Point> moves)
        {
            var piece = board.Squares[point.X, point.Y];
            var toBeRemovedPoints = new List<Point>();
            foreach (var move in moves)
            {
                var boardCopy = board.MakeMove(point, move);
                if (IsGameState(boardCopy, GameStateRule.CHECK, piece.Color))
                {
                    toBeRemovedPoints.Add(move);
                }
            }
            foreach (var move in toBeRemovedPoints)
                moves.Remove(move);

            return moves;
        }
    }
}
