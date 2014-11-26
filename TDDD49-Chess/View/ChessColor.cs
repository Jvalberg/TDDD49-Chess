using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.View
{
    public class ChessColor
    {
        public static int NONE = -1;
        public static int WHITE = 0;
        public static int BLACK = 1;

        public static int ConvertFromGameColor(int color)
        {
            //Currently encoded the same way.
            return color;
        }

        public static int ConvertToGameColor(int color)
        {
            return color;
        }

        public static String ConvertToString(int color)
        {
            switch(color)
            {
                case 0: return "White";
                case 1: return "Black";
                default: return "None";
            }
        }
    }
}
