using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.View
{
    public class ViewModelLocator
    {
        private ChessboardViewModel _chessBoardViewModel;
        public ChessboardViewModel ChessBoardViewModel
        {
            get
            {
                if (_chessBoardViewModel == null)
                    _chessBoardViewModel = new ChessboardViewModel();
                return _chessBoardViewModel;
            }
        }

        private MenuViewModel _menuViewModel;
        public MenuViewModel MenuViewModel
        {
            get
            {
                if (_menuViewModel == null)
                    _menuViewModel = new MenuViewModel();
                return _menuViewModel;
            }
        }

        private PlayerViewModel _playerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get
            {
                if (_playerViewModel == null)
                    _playerViewModel = new PlayerViewModel();
                return _playerViewModel;
            }
        }

        private PlayerViewModel _secondPlayerViewModel;
        public PlayerViewModel SecondPlayerViewModel
        {
            get
            {
                if (_secondPlayerViewModel == null)
                    _secondPlayerViewModel = new PlayerViewModel();
                return _playerViewModel;
            }
        }
    }
}
