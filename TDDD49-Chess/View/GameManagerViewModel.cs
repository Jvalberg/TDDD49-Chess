using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDDD49_Chess.AI;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.View.Commands;

namespace TDDD49_Chess.View
{
    public class GameManagerViewModel : ChessObserver, INotifyPropertyChanged
    {
        private PlayerViewModel _player;
        private PlayerViewModel _humanOpponent;
        private IAIChessPlayer _aiOpponent;

        private Boolean _playerIsWhite;
        private Boolean _playerIsBlack;

        public Boolean PlayerIsWhite
        {
            get { return _playerIsWhite; }
            set
            {
                _playerIsWhite = value;
                OnPropertyChanged("PlayerIsWhite");
            }
        }

        public Boolean PlayerIsBlack
        {
            get { return _playerIsBlack; }
            set
            {
                _playerIsBlack = value;
                OnPropertyChanged("PlayerIsBlack");
            }
        }

        private Boolean _isHumanOpponent;
        public Boolean IsHumanOpponent
        {
            get { return _isHumanOpponent; }
            set
            {
                _isHumanOpponent = value;
                OnPropertyChanged("IsHumanOpponent");
            }
        }

        private Boolean _isAIOpponent;
        public Boolean IsAIOpponent
        {
            get { return _isAIOpponent; }
            set
            {
                _isAIOpponent  = value;
                OnPropertyChanged("IsAIOpponent");
            }
        }

        private Persistor.Persistance GLOBAL_PERSISTOR;

        public GameManagerViewModel()
        {
            _player = new PlayerViewModel();
            //_player.RegisterAsPlayer(Color.WHITE);
            _playerIsWhite = true;
            _playerIsBlack = false;
            _humanOpponent = new PlayerViewModel();
            _aiOpponent = new AIChessPlayer();
            //_aiOpponent.AddAI();
            _isHumanOpponent = false;
            _isAIOpponent = true;

            this.RegisterAsObserver();

            GLOBAL_PERSISTOR = new Persistor.Persistance();
            GLOBAL_PERSISTOR.ChessPersistor.Load();

            _mouseDownCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseDown);
            _mouseUpCommand = new RelayCommand<ChessSquareViewModel>(HandleSquareMouseUp);
            _showNewGameDialogCommand = new RelayCommand<Object>(HandleNewGameRequest);
        }

        #region Handle Opponent

        private ICommand _showNewGameDialogCommand;
        public ICommand ShowNewGameDialogCommand
        {
            get { return _showNewGameDialogCommand; }
        }

        private void HandleNewGameRequest(object obj)
        {

            var _selectOpponentDialog = new OpponentView();
            _selectOpponentDialog.DataContext = this;
            var result = _selectOpponentDialog.ShowDialog();
            if(result.HasValue &&
                result.Value)
            {
                if(_aiOpponent.IsActive())
                    _aiOpponent.Dispose();
                if(_humanOpponent.IsActivePlayer())
                    _humanOpponent.Unregister();
                if (_player.IsActivePlayer())
                    _player.Unregister();

                if (_playerIsWhite)
                {
                    _player.Color = Color.WHITE;
                    _player.RegisterAsPlayer(_player.Color);
                }
                else
                {
                    _player.Color = Color.BLACK;
                    _player.RegisterAsPlayer(_player.Color);
                }

                if (IsAIOpponent)
                    _aiOpponent.AddAI();
                else
                {
                    if (_playerIsWhite)
                    {
                        _humanOpponent.Color = Color.BLACK;
                        _humanOpponent.RegisterAsPlayer(_humanOpponent.Color);
                    }
                    else
                    {
                        _humanOpponent.Color = Color.BLACK;
                        _humanOpponent.RegisterAsPlayer(_humanOpponent.Color);
                    }
                }

                _player.NewGame();

                String BlackValue;
                String WhiteValue;
                if(IsAIOpponent)
                {
                    if (_playerIsBlack)
                    {
                        BlackValue = "Player";
                        WhiteValue = "AI";
                    }
                    else
                    {
                        BlackValue = "AI";
                        WhiteValue = "Player";
                    }
                }
                else
                {
                    WhiteValue = "Player";
                    BlackValue = "Player";
                }
                GLOBAL_PERSISTOR.ChessPersistor.SaveMetadata("Black", BlackValue);
                GLOBAL_PERSISTOR.ChessPersistor.SaveMetadata("White", WhiteValue);
            }
        }

        #endregion

        #region Human Player

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand { get { return _mouseDownCommand; } }

        private ICommand _mouseUpCommand;
        public ICommand MouseUpCommand { get { return _mouseUpCommand; } }

        private ChessSquareViewModel _draggedSquare = null;
        private void HandleSquareMouseDown(ChessSquareViewModel vm)
        {
            if(_isHumanOpponent)
            {
                if (_humanOpponent.MouseDownCommand.CanExecute(vm))
                    _humanOpponent.MouseDownCommand.Execute(vm);
            }
            if(_player.MouseDownCommand.CanExecute(vm))
            {
                _player.MouseDownCommand.Execute(vm);
            }
        }

        private void HandleSquareMouseUp(ChessSquareViewModel vm)
        {
            if(_isHumanOpponent)
            {
                if(_humanOpponent.MouseUpCommand.CanExecute(vm))
                    _humanOpponent.MouseUpCommand.Execute(vm);
            }
            if (_player.MouseUpCommand.CanExecute(vm))
            {
                _player.MouseUpCommand.Execute(vm);
            }
        }

        #endregion


        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(property));
        }

        #endregion


        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.BoardLoaded)
            {
                //Register players according to how they where recently played.
                var whiteValue = GLOBAL_PERSISTOR.ChessPersistor.GetMetadataValue("White");
                var blackValue = GLOBAL_PERSISTOR.ChessPersistor.GetMetadataValue("Black");
                if(whiteValue != null && blackValue != null)
                {
                    if(_aiOpponent.IsActive())
                        _aiOpponent.Dispose();
                    if(_player.IsActivePlayer())
                        _player.Unregister();
                    if(_humanOpponent.IsActivePlayer())
                        _humanOpponent.Unregister();

                    if (whiteValue == "Player")
                    {
                        _player.Color = Color.WHITE;
                        _player.RegisterAsPlayer(_player.Color);
                    }

                    if (blackValue == "Player")
                    {
                        if(_player.IsActivePlayer())
                        {
                            _humanOpponent.Color = Color.BLACK;
                            _humanOpponent.RegisterAsPlayer(_humanOpponent.Color);
                        }
                        else
                        {
                            _player.Color = Color.BLACK;
                            _player.RegisterAsPlayer(_player.Color);
                        }
                    }

                    if (!this.IsActiveGame()) //Two players registered{
                    {
                        _aiOpponent.AddAI();
                        IsHumanOpponent = false;
                        IsAIOpponent = true;
                    }
                    else
                    {
                        IsHumanOpponent = true;
                        IsAIOpponent = false;
                    }
                }
                else
                {
                    if (_aiOpponent.IsActive())
                        _aiOpponent.Dispose();
                    if (_player.IsActivePlayer())
                        _player.Unregister();
                    if (_humanOpponent.IsActivePlayer())
                        _humanOpponent.Unregister();
                    _player.Color = Color.WHITE;
                    _player.RegisterAsPlayer(Color.WHITE);
                    _aiOpponent.AddAI();
                    
                }
            }
        }
    }
}
