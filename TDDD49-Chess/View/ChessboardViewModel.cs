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
            SetupBoard();
        }

        public void SetupBoard()
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

            SetupCoreSidePieces(ChessColor.BLACK, 0);
            SetupPawnSidePieces(ChessColor.BLACK, 1);
            SetupPawnSidePieces(ChessColor.WHITE, 6);
            SetupCoreSidePieces(ChessColor.WHITE, 7);

        }

        private void SetupCoreSidePieces(int side, int yoffset)
        {
            GetSquare(0, yoffset).Piece = ChessPiece.ROOK;
            GetSquare(0, yoffset).Side = side;
            GetSquare(1, yoffset).Piece = ChessPiece.BISHOP;
            GetSquare(1, yoffset).Side = side;
            GetSquare(2, yoffset).Piece = ChessPiece.KNIGHT;
            GetSquare(2, yoffset).Side = side;
            GetSquare(3, yoffset).Piece = ChessPiece.QUEEN;
            GetSquare(3, yoffset).Side = side;
            GetSquare(4, yoffset).Piece = ChessPiece.KING;
            GetSquare(4, yoffset).Side = side;
            GetSquare(5, yoffset).Piece = ChessPiece.KNIGHT;
            GetSquare(5, yoffset).Side = side;
            GetSquare(6, yoffset).Piece = ChessPiece.BISHOP;
            GetSquare(6, yoffset).Side = side;
            GetSquare(7, yoffset).Piece = ChessPiece.ROOK;
            GetSquare(7, yoffset).Side = side;
        }

        private void SetupPawnSidePieces(int side, int yoffset)
        {
            GetSquare(0, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(0, yoffset).Side = side;
            GetSquare(1, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(1, yoffset).Side = side;
            GetSquare(2, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(2, yoffset).Side = side;
            GetSquare(3, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(3, yoffset).Side = side;
            GetSquare(4, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(4, yoffset).Side = side;
            GetSquare(5, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(5, yoffset).Side = side;
            GetSquare(6, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(6, yoffset).Side = side;
            GetSquare(7, yoffset).Piece = ChessPiece.PAWN;
            GetSquare(7, yoffset).Side = side;
        }

        private ChessSquareViewModel GetSquare(int x, int y)
        {
            int arrayPos = x * 8 + y;
            return ChessSquares[arrayPos];
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
