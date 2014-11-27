using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public class Color
    {
        public static int NONE = -1;
        public static int WHITE = 0;
        public static int BLACK = 1;

        public static Boolean IsNotColor(int color)
        {
            return color != WHITE && color != BLACK;
        }
    }
}
