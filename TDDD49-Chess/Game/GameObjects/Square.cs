using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public struct Square
    {
        private int _piece;
        public int Piece { get { return _piece; } set { _piece = value; } }
        private int _color;
        public int Color { get { return _color; } set { _color = value; } }

        public Square(int piece, int color)
        {
            _piece = piece;
            _color = color;
        }

        public static Square Empty()
        {
            return new Square(Pieces.NONE, GameObject.Color.NONE);
        }
    }
}
