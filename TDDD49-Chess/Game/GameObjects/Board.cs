using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public class Board
    {
        public Square[,] Squares { get; set; }

        public Board()
        {
            Squares = new Square[8,8];
            Clear();
        }

        public Board(Square[,] board)
        {
            Squares = new Square[8, 8];
            for (int i = 0; i < 8; i++)
                for (int x = 0; x < 8; x++)
                    Squares[i, x] = board[i, x];
        }

        /// <summary>
        /// Returns all the pieces belong to the specified color.
        /// If the color is "NONE", all pieces are returned.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public IList<Point> GetAllPieces(int color)
        {
            return Board.GetAllPieces(this, color);
        }

        public void Clear()
        {
            Board.Clear(this);
        }
        
        public Board GetCopy()
        {
            return Board.GetCopy(this);
        }

        #region Static Methods

        /// <summary>
        /// The starting Y position of the black pawns.
        /// This is always the same (Black starts at the top)
        /// </summary>
        public static int BLACK_START_PAWN_ROW = 1;

        /// <summary>
        /// The starting Y position of the white pawns
        /// This is always the same (White starts at the bottom)
        /// </summary>
        public static int WHITE_START_PAWN_ROW = 7;

        /// <summary>
        /// The direction for the white pieces. (They move upward)
        /// </summary>
        public static int WHITE_DIRECTION = -1;

        /// <summary>
        /// Black pieces move downward
        /// </summary>
        public static int BLACK_DIRECTION = 1;

        /// <summary>
        /// Returns all the pieces belong to the specified color.
        /// If the color is "NONE", all pieces are returned.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static List<Point> GetAllPieces(Board board, int color)
        {
            var pieces = new List<Point>();
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    if(board.Squares[x, y].Piece != Pieces.NONE)
                    {
                        if (color == Color.NONE ||
                            board.Squares[x, y].Color == color)
                            pieces.Add(new Point(x, y));
                    }
                }
            }
            return pieces;
        }

        public static void Clear(Board board)
        {
            for (int i = 0; i < 8; i++)
                for (int x = 0; x < 8; x++)
                    board.Squares[i, x] = new Square()
                    {
                        Color = Color.NONE,
                        Piece = Pieces.NONE
                    };
        }

        public static Board GetCopy(Board board)
        {
            return new Board(board.Squares);
        }

        #endregion
    }
}
