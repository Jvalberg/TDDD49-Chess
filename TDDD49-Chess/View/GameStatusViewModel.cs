using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;
using TDDD49_Chess.Game.Rules;

namespace TDDD49_Chess.View
{
    public class GameStatusViewModel : ChessObserver, INotifyPropertyChanged
    {
        private String _currentTurn;
        public String CurrentTurn
        {
            get { return _currentTurn; }
            set
            {
                _currentTurn = value;
                OnPropertyChanged("CurrentTurn");
            }
        }


        private String _gameIsOver;
        public String GameIsOver
        {
            get { return _gameIsOver; }
            set
            {
                _gameIsOver = value;
                OnPropertyChanged("GameIsOver");
            }
        }

        private String _gameState;
        public String GameState
        {
            get { return _gameState; }
            set
            {
                _gameState = value;
                OnPropertyChanged("GameState");
            }
        }
        
        public GameStatusViewModel()
        {
            if(!this.RegisterAsObserver())
            {
                //Handle error some way.
                setEmptyStatus();
            }
            else
            {
                fetchChessStatus();
            }
        }

        private void setEmptyStatus()
        {
            GameState = "<unkown>";
            CurrentTurn = "<unkown>";
            GameIsOver = "<unkown>";
        }

        private void fetchChessStatus()
        {
            if(this.IsGameOver())
            {
                GameIsOver = "The Game is over";
                if(this.GetRules().IsGameState(this.GetBoardCopy(), GameStateRule.CHECKMATE, Color.BLACK))
                {
                    GameState = "White has won";
                }
                else if(this.GetRules().IsGameState(this.GetBoardCopy(), GameStateRule.CHECKMATE, Color.WHITE))
                {
                    GameState = "Black has won";
                }
                else
                {
                    GameState = "The game is a draw";
                }
                CurrentTurn = "None";
            }
            else if(!this.IsActiveGame())
            {
                GameIsOver = "<unkown>";
                GameState = "Register more players to start.";
                CurrentTurn = "<unkown>";
            }
            else
            {
                GameIsOver = "The game is on";
                if(this.GetRules().IsGameState(this.GetBoardCopy(), GameStateRule.CHECK, Color.BLACK))
                {
                    GameState = "Black is checked.";
                }
                else if(this.GetRules().IsGameState(this.GetBoardCopy(), GameStateRule.CHECK, Color.WHITE))
                {
                    GameState = "White is checked";
                }
                else
                {
                    GameState = "";
                }
                if (this.IsCurrentTurn(Color.BLACK))
                    CurrentTurn = "Black";
                else
                    CurrentTurn = "White";
            }
        }

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.NewGame ||
                args.Trigger == GameUpdatedTrigger.MovedPiece || 
                args.Trigger == GameUpdatedTrigger.BoardLoaded)
            {
                fetchChessStatus();
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
