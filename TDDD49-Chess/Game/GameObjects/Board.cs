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

        public void Clear()
        {
            Board.Clear(this);
        }
        
        public Board GetCopy()
        {
            return Board.GetCopy(this);
        }


        #region Static Methods

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
