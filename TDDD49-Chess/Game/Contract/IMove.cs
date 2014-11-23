using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.Contract;

namespace TDDD49_Chess.Game.Contract
{
    public interface IMove
    {
        Point From { get; }
        Point To { get; }
        IPiece CapturedPiece { get; }
    }
}
