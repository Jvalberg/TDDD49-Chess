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

        public String ToString()
        {
            return Piece + ";" + Color;
        }

        public static Square FromString(String s)
        {
            var values = s.Split(';');
            if (values.Length == 2)
            {
                try
                {
                    int piece = Convert.ToInt32(values[0]);
                    if (Pieces.IsNotPiece(piece))
                        piece = Pieces.NONE;
                    int color = Convert.ToInt32(values[1]);
                    if (TDDD49_Chess.Game.GameObject.Color.IsNotColor(color))
                        color = TDDD49_Chess.Game.GameObject.Color.NONE;
                    return new Square(piece, color);
                }
                catch (Exception e)
                {

                }
            }
            return Square.Empty();
        }
    }
}
