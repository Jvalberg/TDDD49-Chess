using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class PawnMovementRule : IMovementRule
    {
        public IList<Point> ValidMoves(Board board, Point coordinates)
        {
            List<Point> validMoves = new List<Point>();

            //Assuming coordinates correspond to a pawn.
            Square square = board.Squares[coordinates.X, coordinates.Y];
            if(square.Color == Color.NONE)
            {
                throw new Exception("Unkown color for the specified piece. Cannot move.");
            }

            int startRow = square.Color == Color.WHITE ? Board.WHITE_START_PAWN_ROW : Board.BLACK_START_PAWN_ROW;
            int direction = square.Color == Color.WHITE ? Board.WHITE_DIRECTION : Board.BLACK_DIRECTION;
            if (insideBoardBounds(coordinates))
            {
                //The special two step move for a pawn.
                //only valid if:
                //1) pawn has not moved
                //2) no piece is in the square inbetween
                //3) no piece is in the destination square.
                if (coordinates.Y == startRow &&
                    Pieces.IsNotPiece(board.Squares[coordinates.X, coordinates.Y + direction].Piece) &&
                    Pieces.IsNotPiece(board.Squares[coordinates.X, coordinates.Y + 2 * direction].Piece))
                    validMoves.Add(new Point(coordinates.X, coordinates.Y + 2 * direction));

                //The standard one step move for a pawn.
                //Only valid if it's inside the board bounds and
                //No piece is standing there
                if (Pieces.IsNotPiece(board.Squares[coordinates.X, coordinates.Y + direction].Piece))
                {
                    validMoves.Add(new Point(coordinates.X, coordinates.Y + direction));
                }

                //Capturing with a pawn.
                if (!Pieces.IsNotPiece(board.Squares[coordinates.X + 1, coordinates.Y + direction].Piece)
                    && board.Squares[coordinates.X + 1, coordinates.Y + direction].Color != square.Color)
                {
                    validMoves.Add(new Point(coordinates.X + 1, coordinates.Y + direction));
                }
                if (!Pieces.IsNotPiece(board.Squares[coordinates.X - 1, coordinates.Y + direction].Piece)
                    && board.Squares[coordinates.X + 1, coordinates.Y + direction].Color != square.Color)
                {
                    validMoves.Add(new Point(coordinates.X - 1, coordinates.Y + direction));
                }
            }

            return validMoves;
        }

        private bool insideBoardBounds(Point point)
        {
            return point.Y >= Board.BLACK_START_PAWN_ROW && point.Y <= Board.WHITE_START_PAWN_ROW;
        }
    }
}
