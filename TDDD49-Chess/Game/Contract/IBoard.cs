using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TDDD49_Chess.Game.Contract
{
    public interface IBoard
    {
        void AddPiece(IPiece piece);
        void RemovePiece(Point coordinates);
        void GetPiece(Point coordinates);
    }
}
