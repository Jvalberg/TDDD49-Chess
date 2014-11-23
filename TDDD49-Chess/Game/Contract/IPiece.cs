using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TDDD49_Chess.Game.Contract
{
    public enum PieceColor { None, White, Black };

    public interface IPiece
    {
        PieceColor Color { get; }
        Point Coordinates { get; }
        IList<Point> GetLegalMoves();
    }
}
