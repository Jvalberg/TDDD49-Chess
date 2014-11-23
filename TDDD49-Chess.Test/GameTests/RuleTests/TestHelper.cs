using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;

namespace TDDD49_Chess.Test.GameTests.RuleTests
{
    public class TestHelper
    {
        public static bool FoundPosition(IList<Point> list, Point position)
        {
            foreach (var p in list)
                if (p.X == position.X &&
                    p.Y == position.Y)
                    return true;
            return false;
        }
    }
}
