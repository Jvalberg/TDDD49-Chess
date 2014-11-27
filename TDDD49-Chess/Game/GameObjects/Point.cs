using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public struct Point
    {
        private int _x;
        public int X { get { return _x; } set { _x = value; } }
        private int _y;
        public int Y { get { return _y; } set { _y = value; } }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public String ToString()
        {
            return X + ";" + Y;
        }
        public static Point FromString(String s)
        {
            var values = s.Split(';');
            if (values.Length == 2)
            {
                try
                {
                    int x = Convert.ToInt32(values[0]);
                    int y = Convert.ToInt32(values[1]);
                    return new Point(x, y);
                }
                catch(Exception e)
                {

                }
            }
            return new Point(-1, -1);
        }
    }
}
