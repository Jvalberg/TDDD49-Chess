using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public float Width { get { return 32.0f; } }
        public float Height { get { return 32.0f; } }

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
