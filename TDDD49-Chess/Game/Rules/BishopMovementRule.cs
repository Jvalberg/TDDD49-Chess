using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class BishopMovementRule : IMovementRule
    {
        public IList<Point> ValidMoves(Board board, Point p)
        {
            var bishop = board.Squares[p.X, p.Y];
            var validMoves = new List<Point>();

            addMoves(-1, -1, p, bishop.Color, validMoves, board);
            addMoves(1, 1, p, bishop.Color, validMoves, board);
            addMoves(-1, 1, p, bishop.Color, validMoves, board);
            addMoves(1, -1, p, bishop.Color, validMoves, board);

            return validMoves;
        }

        private void addMoves(int xDirection, int yDirection, Point start, int color ,IList<Point> moves, Board board)
        {
            Point move = new Point(start.X + xDirection, start.Y + yDirection);
            while (inBoard(move))
            {
                if(board.Squares[move.X, move.Y].Piece != Pieces.NONE)
                {
                    if (board.Squares[move.X, move.Y].Color != color)
                        moves.Add(move);
                    break;
                }

                moves.Add(move);
                move.X += xDirection;
                move.Y += yDirection;
            }
        }

        private bool inBoard(Point p)
        {
            return p.X >= 0 && p.X <= 7 && p.Y >= 0 && p.Y <= 7;
        }
    }
}
