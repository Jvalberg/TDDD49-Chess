using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Game.Rules
{
    public class ColorWonGameStateRule : IGameStateRule
    {
        private int _color;

        public ColorWonGameStateRule(int color)
        {
            _color = color;
        }
        public bool IsTrue(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
