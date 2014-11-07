using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.View
{
    public class ChessboardViewModel : INotifyPropertyChanged
    {
        private float _boardWidth;
        public float BoardWidth
        {
            get { return _boardWidth; }
            set
            {
                _boardWidth = value;
                OnPropertyChanged("BoardWidth");
                OnPropertyChanged("SquareWidth");
            }
        }
        
        private float _boardHeight;
        public float BoardHeight
        {
            get { return _boardHeight; }
            set
            {
                _boardHeight = value;
                OnPropertyChanged("BoardHeight");
                OnPropertyChanged("SquareHeight");
            }
        }

        public float SquareWidth
        {
            get { return _boardWidth / 8.0f; }
        }

        public float SquareHeight
        {
            get { return _boardHeight / 8.0f; }
        }

        private ObservableCollection<ChessSquareViewModel> _chessSquares;
        public ObservableCollection<ChessSquareViewModel> ChessSquares
        {
            get { return _chessSquares; }
            set
            {
                _chessSquares = value;
                OnPropertyChanged("ChessSquares");
            }
        }

        public ChessboardViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            BoardWidth = 768;
            BoardHeight = 768;
            ChessSquares = new ObservableCollection<ChessSquareViewModel>();
            for(int x = 0; x < 8; x++)
                for(int y = 0; y < 8; y++)
                    ChessSquares.Add(new ChessSquareViewModel() 
                        {
                            X = x,
                            Y = y
                        });
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
