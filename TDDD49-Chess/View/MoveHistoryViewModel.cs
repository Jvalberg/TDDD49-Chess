using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.View
{
    public class MoveViewModel : INotifyPropertyChanged
    {
        private int _moveNumber;
        public int MoveNumber
        {
            get { return _moveNumber; }
            set
            {
                _moveNumber = value;
                OnPropertyChanged("MoveNumber");
            }
        }

        private String _from;
        public String From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged("");
            }
        }

        private String _to;
        public String To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged("To");
            }
        }

        private String _movedPieceDetails;
        public String MovedPieceDetails
        {
            get { return _movedPieceDetails; }
            set
            {
                _movedPieceDetails = value;
                OnPropertyChanged("MovedPieceDetails");
            }
        }

        private String _caughtPieceDetails;
        public String CaughtPieceDetails
        {
            get { return _caughtPieceDetails; }
            set
            {
                _caughtPieceDetails = value;
                OnPropertyChanged("CaughtPieceDetails");
            }
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

    public class MoveHistoryViewModel : ChessObserver, INotifyPropertyChanged
    {
        private ObservableCollection<MoveViewModel> _moves;
        public ObservableCollection<MoveViewModel> Moves
        {
            get { return _moves; }
            set
            {
                _moves = value;
                OnPropertyChanged("Moves");
            }
        }

        private ICollectionView _sortedMoves;
        public ICollectionView SortedMoves
        {
            get { return _sortedMoves; }
            set
            {
                SortedMoves = value;
                OnPropertyChanged("SortedMoves");
            }
        }

        public MoveHistoryViewModel()
        {
            this.RegisterAsObserver();
            _moves = new ObservableCollection<MoveViewModel>();
            _sortedMoves = CollectionViewSource.GetDefaultView(_moves);
            _sortedMoves.SortDescriptions.Add(new SortDescription("MoveNumber", ListSortDirection.Descending));
            GameUpdated(new GameUpdatedArgs(GameUpdatedTrigger.BoardLoaded));
        }

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.BoardLoaded || 
                args.Trigger == GameUpdatedTrigger.MovedPiece ||
                args.Trigger == GameUpdatedTrigger.NewGame)
            {
                Moves.Clear();
                var moveHistory = this.GetMoveHistory();
                int counter = 1;
                foreach (var move in moveHistory)
                {
                    MoveViewModel moveVM = new MoveViewModel();
                    moveVM.MoveNumber = counter;
                    moveVM.From = "(" + move.From.X + ", " + move.From.Y + ")";
                    moveVM.To = "(" + move.To.X + ", " + move.To.Y + ")";
                    moveVM.MovedPieceDetails = ChessColor.ConvertToString(ChessColor.ConvertFromGameColor(move.MovedPiece.Color)) +
                        ":" + ChessPiece.ConvertToString(ChessPiece.ConvertFromGamePiece(move.MovedPiece.Piece));
                    moveVM.CaughtPieceDetails = ChessColor.ConvertToString(ChessColor.ConvertFromGameColor(move.CapturedPiece.Color)) +
                        ":" + ChessPiece.ConvertToString(ChessPiece.ConvertFromGamePiece(move.CapturedPiece.Piece));
                    Moves.Add(moveVM);
                    counter++;
                }
            }

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
