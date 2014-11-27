using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.View.Commands;

namespace TDDD49_Chess.View
{
    public class PlayerViewModel : ChessPlayer
    {
        public int Color { get; set; }

        public PlayerViewModel()
        {

            //Only triggers command when it's ones turn
            _mouseDownCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseDown, 
                (ChessSquareViewModel vm) => ( this.IsCurrentTurn(ChessColor.ConvertToGameColor(Color))));
            _mouseUpCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseUp, 
                (ChessSquareViewModel vm) => (this.IsCurrentTurn(ChessColor.ConvertToGameColor(Color))));
            _newGameCommand = new RelayCommand<Object>(HandleNewGameRequest);
        }

        #region Commands

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand { get { return _mouseDownCommand; } }

        private ICommand _mouseUpCommand;
        public ICommand MouseUpCommand { get { return _mouseUpCommand; } }

        private ICommand _newGameCommand;
        public ICommand NewGameCommand { get { return _newGameCommand; } }

        private ChessSquareViewModel _draggedSquare = null;
        private void HandleSquareMouseDown(ChessSquareViewModel vm)
        {
            if(this.IsActivePlayer())
            {
                _draggedSquare = vm;
            }
        }

        private void HandleSquareMouseUp(ChessSquareViewModel vm)
        {
            if(_draggedSquare != null && this.IsActivePlayer())
            {
                //A move has been tried.

                if(_draggedSquare.Side == Color &&
                    _draggedSquare.Piece != ChessPiece.NONE) //Dragged correct piece.
                {
                    this.TryMove(new Point(_draggedSquare.X, _draggedSquare.Y),
                                 new Point(vm.X, vm.Y));
                }

                _draggedSquare = null;
            }
        }


        private void HandleNewGameRequest(object obj)
        {
            this.NewGame();
        }

        #endregion
    }
}
