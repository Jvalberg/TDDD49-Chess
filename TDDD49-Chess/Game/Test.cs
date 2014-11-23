using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game
{

    public class Piece
    {
        public static int NONE = -1;
        public static int KING = 0;
        public static int QUEEN = 1;
        public static int BISHOP = 2;
        public static int KNIGHT = 3;
        public static int ROOK = 4;
        public static int PAWN = 5;
    }

    public class Color
    {
        public static int UNKNOWN = -1;
        public static int WHITE = 0;
        public static int BLACK = 1;
    }

    struct Point { public int X; public int Y; }
        
    struct Square
    {
        public int Piece { get; set; }
        public int Color { get; set; }
    }

    class Board
    {
        Square [,] _board = new Square[8, 8];


        private static IMovementRule[] _MovementRules;

        public static IList<Point> GetPiecesFor(Square[,] board, int color);
        public static IList<Point> GetPieceMoves(Square[,] board, Point position)
        {
            if(_MovementRules == null)
            {
                _MovementRules = new IMovementRule[6];
                _MovementRules[Piece.KING] = new KingMovementRule();
            }
            
            Square s = board[position.X, position.Y];

            return _MovementRules[s.Piece].GetValidMoves(board, position);
        }
        public static Boolean IsGameOver(Square[,] board, int color);
    }

    interface IMovementRule
    {
        IList<Point> GetValidMoves(Square[,] board, Point position);
    }

    class KingMovementRule : IMovementRule
    {
        public IList<Point> GetValidMoves(Square[,] board, Point position)
        {
            return null;
        }
    }

}
