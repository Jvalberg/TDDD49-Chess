using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.View.Commands;

namespace TDDD49_Chess.View
{
    public class ChessboardViewModel : ChessObserver,  INotifyPropertyChanged
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

        #region Commands

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand { get { return _mouseDownCommand; } }

        private ICommand _mouseUpCommand;
        public ICommand MouseUpCommand { get { return _mouseUpCommand; } }

        #endregion

        public ChessboardViewModel()
        {
            SetupBoard();
            _mouseDownCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseDown);
            _mouseUpCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseUp);

            //This ChessBoardViewModel is an observer of a game.
            if(!this.RegisterAsObserver())
            {
                //Could not connect to chess game, handle somehow.
            }
            else
            {
                //GameUpdated(new GameUpdatedArgs);
                GameUpdated(new GameUpdatedArgs(GameUpdatedTrigger.BoardLoaded));
            }
        }

        #region Commands


        private ChessSquareViewModel selectedSquare;
        private IList<Point> validMoves;
        private void HandleSquareMouseUp(ChessSquareViewModel vm)
        {
            if(selectedSquare != null && validMoves != null)
            {
                foreach (var square in ChessSquares)
                {
                    square.ValidMove = false;
                }
            }
        }

        private void HandleSquareMouseDown(ChessSquareViewModel vm)
        {
            selectedSquare = vm;
            var board = this.GetBoardCopy();
            validMoves = this.GetRules().MovementRules.ValidMoves(board, new Point(vm.X, vm.Y));
            validMoves = this.GetRules().FilterCheckMoves(this.GetBoardCopy(), new Point(vm.X, vm.Y), validMoves);
            foreach (var square in ChessSquares)
            {
                square.ValidMove = validMoves.Contains(new Point(square.X, square.Y)) &&
                                    !this.IsGameOver() &&
                                    this.IsCurrentTurn(ChessColor.ConvertToGameColor(vm.Side)) &&
                                    this.IsActiveGame();
            }
        }

        /*
        private Boolean _isDragging;
        private ChessSquareViewModel _draggedChessSquare;
        private void HandleSquareMouseDown(ChessSquareViewModel vm)
        {
            _isDragging = true;
            _draggedChessSquare = vm;
        }

        private void HandleSquareMouseUp(ChessSquareViewModel vm)
        {
            if(_isDragging)
            {
                _isDragging = false;
                if(vm != _draggedChessSquare)
                {
                    vm.Piece = _draggedChessSquare.Piece;
                    vm.Side = _draggedChessSquare.Side;
                    _draggedChessSquare.Piece = ChessPiece.NONE;
                    _draggedChessSquare.Side = ChessColor.NONE;
                }
            }
        }
         * */

        #endregion

        #region ChessGame Methods

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if (args.Trigger == GameUpdatedTrigger.BoardLoaded ||
                args.Trigger == GameUpdatedTrigger.MovedPiece ||
                args.Trigger == GameUpdatedTrigger.NewGame)
            {
                //The game has updated somehow.
                var board = this.GetBoardCopy();
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        ChessSquareViewModel vm = GetSquare(x, y);
                        var square = board.Squares[x, y];
                        vm.Piece = ChessPiece.ConvertFromGamePiece(square.Piece);
                        vm.Side = ChessColor.ConvertFromGameColor(square.Color);
                    }
                }
            }
        }

        #endregion

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

            //SetupCoreSidePieces(ChessColor.BLACK, 0);
            //SetupPawnSidePieces(ChessColor.BLACK, 1);
            //SetupPawnSidePieces(ChessColor.WHITE, 6);
            //SetupCoreSidePieces(ChessColor.WHITE, 7);

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
