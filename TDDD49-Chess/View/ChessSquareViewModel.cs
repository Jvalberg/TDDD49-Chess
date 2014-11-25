using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TDDD49_Chess.View
{
    public class ChessSquareViewModel : INotifyPropertyChanged
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set 
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        private int _piece;
        public int Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                OnPropertyChanged("Piece");
            }
        }

        private int _side;
        public int Side
        {
            get { return _side; }
            set
            {
                _side = value;
                OnPropertyChanged("Side");
            }
        }

        private Boolean _validMove;
        public Boolean ValidMove
        {
            get { return _validMove; }
            set
            {
                _validMove = value;
                OnPropertyChanged("ValidMove");
            }
        }

        public ChessSquareViewModel()
        {
            Piece = ChessPiece.NONE;
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
