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

        public static int GetPieceValue(int piece)
        {
            switch (piece)
            {
                case 0: return 0;
                case 1: return 9;
                case 2: return 3;
                case 3: return 3;
                case 4: return 5;
                case 5: return 1;
                default: return 0;
            }
        }
    }
}
