using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.View.Commands;

namespace TDDD49_Chess.View
{
    public class PlayerViewModel : HumanChessPlayer
    {
        public PlayerViewModel()
        {
            _mouseDownCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseDown);
            _mouseUpCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseUp);
        }

        #region Commands

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand { get { return _mouseDownCommand; } }

        private ICommand _mouseUpCommand;
        public ICommand MouseUpCommand { get { return _mouseUpCommand; } }

        private void HandleSquareMouseUp(ChessSquareViewModel vm)
        {
        }

        private void HandleSquareMouseDown(ChessSquareViewModel vm)
        {
        }

        #endregion

    }
}
