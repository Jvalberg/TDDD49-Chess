using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class QueenMovementRule : IMovementRule
    {

        private IMovementRule _rookMovementRule;
        private IMovementRule _bishopMovementRule;

        public QueenMovementRule()
        {
            _rookMovementRule = new RookMovementRule();
            _bishopMovementRule = new BishopMovementRule();
        }

        public IList<Point> ValidMoves(Board board, Point coordinates)
        {
            var validMoves = new List<Point>();
            validMoves.AddRange(_rookMovementRule.ValidMoves(board, coordinates));
            validMoves.AddRange(_bishopMovementRule.ValidMoves(board, coordinates));
            return validMoves;
        }
    }
}
