using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class KingMovementRule : IMovementRule
    {
        public IList<Point> ValidMoves(Board board, Point p)
        {
            Square king = board.Squares[p.X, p.Y];
            var possibleMoves = new List<Point>();
            var validMoves = new List<Point>();
            Point move = new Point(p.X, p.Y);

            /*
             * (-1, -1) (0, -1) (+1, -1)
             * (-1, 0)  (0,  0) (+1, 0)
             * (-1, +1) (0, +1) (+1, +1)
             * */
            possibleMoves.Add(new Point(p.X - 1, p.Y - 1));
            possibleMoves.Add(new Point(p.X - 0, p.Y - 1));
            possibleMoves.Add(new Point(p.X + 1, p.Y - 1));
            possibleMoves.Add(new Point(p.X - 1, p.Y - 0));
            possibleMoves.Add(new Point(p.X + 1, p.Y - 0));
            possibleMoves.Add(new Point(p.X - 1, p.Y + 1));
            possibleMoves.Add(new Point(p.X - 0, p.Y + 1));
            possibleMoves.Add(new Point(p.X + 1, p.Y + 1));
            foreach (var point in possibleMoves)
            {
                if (inBoard(point) && !isFriendlyPlayer(board, point, king.Color))
                    validMoves.Add(point);
            }
            return validMoves;
        }

        bool isFriendlyPlayer(Board board, Point p, int color)
        {
            return board.Squares[p.X, p.Y].Color == color;
        }

        bool inBoard(Point p)
        {
            return p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7;
        }

    }
}
