using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class GameStateRule
    {
        public static int DRAW = 0;
        public static int BLACK_WON = 1;
        public static int WHITE_WON = 2;

        public static Boolean Exists(int state)
        {
            return state >= 0 && state <= 2;
        }
    }

    public interface IGameStateRule
    {
        Boolean IsTrue(Board board, int color);
    }
}
