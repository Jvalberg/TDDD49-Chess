using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public class Pieces
    {
        public static int NONE = -1;
        public static int KING = 0;
        public static int QUEEN = 1;
        public static int BISHOP = 2;
        public static int KNIGHT = 3;
        public static int ROOK = 4;
        public static int PAWN = 5;

        public static Boolean IsNotPiece(int piece)
        {
            return piece == NONE;
        }
    }
}
