using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class KnightMovementRule : IMovementRule
    {
        public IList<Point> ValidMoves(Board board, Point p)
        {
            /*
             * 0 0 0 0 0 0 0 0
             * 0 0 1 0 1 0 0 0 (k.X - 1, k.Y - 2)    (k.x + 1, k.y - 2)
             * 0 1 0 0 0 1 0 0 (k.x - 2, k.y -1)     (k.x + 2, k.y - 1)
             * 0 0 0 K 0 0 0 0 
             * 0 1 0 0 0 1 0 0 (k.x - 2, k.y + 1)    (k.x + 2, k.y + 1)
             * 0 0 1 0 1 0 0 0 (k.x - 1, k.y + 2)    (k.x + 1, k.y + 2)
             * 0 0 0 0 0 0 0 0
             * 0 0 0 0 0 0 0 0
             * */
            var knight = board.Squares[p.X, p.Y];
            var possibleMoves = new List<Point>();
            possibleMoves.Add(new Point(p.X - 1, p.Y - 2));
            possibleMoves.Add(new Point(p.X + 1, p.Y - 2));

            possibleMoves.Add(new Point(p.X - 2, p.Y - 1));
            possibleMoves.Add(new Point(p.X + 2, p.Y - 1));

            possibleMoves.Add(new Point(p.X - 2, p.Y + 1));
            possibleMoves.Add(new Point(p.X + 2, p.Y + 1));

            possibleMoves.Add(new Point(p.X - 1, p.Y + 2));
            possibleMoves.Add(new Point(p.X + 1, p.Y + 2));

            var validMoves = new List<Point>();
            foreach(var point in possibleMoves)
            {
                if (inBoard(point) &&
                    !isFriendlyPiece(board, point, knight.Color))
                    validMoves.Add(point);
            }
            return validMoves;
        }

        bool isFriendlyPiece(Board b, Point p, int color)
        {
            return b.Squares[p.X, p.Y].Color == color;
        }

        bool inBoard(Point p)
        {
            return p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7;
        }
    }
}
