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
    }
}
