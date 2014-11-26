using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.View
{
    public class ChessPiece
    {
        public static int NONE = -1;
        public static int KING = 0;
        public static int QUEEN = 1;
        public static int BISHOP = 2;
        public static int KNIGHT = 3;
        public static int ROOK = 4;
        public static int PAWN = 5;

        public static int ConvertFromGamePiece(int piece)
        {
            //Currently encoded the same way.
            return piece;
        }

        public static String ConvertToString(int piece)
        {
            switch(piece)
            {
                case 0: return "K"; 
                case 1: return "Q"; 
                case 2: return "B"; 
                case 3: return "Kn"; 
                case 4: return "R"; 
                case 5: return "P";
                default : return "<none>"; 
            }
        }
    }
}
