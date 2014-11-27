using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.GameObject
{
    public class Move
    {
        private int _sequenceNumber;
        public int SequenceNumber { get { return _sequenceNumber; } }

        private Point _from;
        public Point From { get { return _from; } }

        private Point _to;
        public Point To { get { return _to; } }

        private Square _movedPiece;
        public Square MovedPiece { get { return _movedPiece; } }

        private Square _capturedPiece;
        public Square CapturedPiece { get { return _capturedPiece; } }
        
        public Move(int sequenceNumber, Point from, Point to, Square moved, Square captured)
        {
            _from = from;
            _to = to;
            _movedPiece = moved;
            _capturedPiece = captured;
            _sequenceNumber = sequenceNumber;
        }

    }
}
