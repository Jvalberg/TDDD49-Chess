using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.AI
{
    public class ChessRandomMoveAlgorithm : IChessMoveAlgorithm
    {
        private IChessPlayer _player;
        private Random _random;

        public ChessRandomMoveAlgorithm(IChessPlayer player)
        {
            _player = player;
            _random = new Random();
        }

        public Tuple<Point, Point> GetNextMove(Board board, int color)
        {
            var pieces = board.GetAllPieces(color);
            var rndPiece = _random.Next(pieces.Count);
            if (rndPiece >= 0 && rndPiece < pieces.Count && pieces.Count > 0)
            {
                var validMoves = _player.GetRules().MovementRules.ValidMoves(board, pieces[rndPiece]);
                var rndMove = _random.Next(validMoves.Count);
                if (rndMove >= 0 && rndMove < validMoves.Count && validMoves.Count > 0)
                {
                    return new Tuple<Point,Point>(pieces[rndPiece], validMoves[rndMove]);
                }
            }
            return null;
        }
    }
}
