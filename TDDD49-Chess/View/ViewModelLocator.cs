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
        /*
        private PlayerViewModel _playerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get
            {
                if (_playerViewModel == null)
                {
                    _playerViewModel = new PlayerViewModel();
                    _playerViewModel.Color = ChessColor.WHITE;
                    _playerViewModel.RegisterAsPlayer(_playerViewModel.Color);
                }
                return _playerViewModel;
            }
        }

        private PlayerViewModel _secondPlayerViewModel;
        public PlayerViewModel SecondPlayerViewModel
        {
            get
            {
                if (_secondPlayerViewModel == null)
                {
                    _secondPlayerViewModel = new PlayerViewModel();
                    _secondPlayerViewModel.Color = ChessColor.BLACK;
                    //_secondPlayerViewModel.RegisterAsPlayer(_secondPlayerViewModel.Color);
                }
                return _secondPlayerViewModel;
            }
        }
        */

        private GameStatusViewModel _gameStatusViewModel;
        public GameStatusViewModel GameStatusViewModel
        {
            get
            {
                if (_gameStatusViewModel == null)
                    _gameStatusViewModel = new GameStatusViewModel();
                return _gameStatusViewModel;
            }
        }

        private MoveHistoryViewModel _moveHistoryViewModel;
        public MoveHistoryViewModel MoveHistoryViewModel
        {
            get
            {
                if (_moveHistoryViewModel == null)
                    _moveHistoryViewModel = new MoveHistoryViewModel();
                return _moveHistoryViewModel;
            }
        }

        private GameManagerViewModel _opponentViewModel;
        public GameManagerViewModel GameManagerViewModel
        {
            get
            {
                if (_opponentViewModel == null)
                    _opponentViewModel = new GameManagerViewModel();
                return _opponentViewModel;
            }
        }
    }
}
