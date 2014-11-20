using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.Game
{
    public class ChessEngine : IChessEngine
    {

        private IList<IChessObserver> _observers;
        private Dictionary<int, IChessPlayer> _players;

        public ChessEngine()
        {
            Initialize();
        }

        public void Initialize()
        {
            _observers = new List<IChessObserver>();
            _players = new Dictionary<int, IChessPlayer>();
        }

        public bool TryMove(GameObject.Point from, GameObject.Point to)
        {
            ChessGameChanged();
            return true;
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public bool IsCurrentTurn(int color)
        {
            throw new NotImplementedException();
        }

        public GameObject.Board GetBoardCopy()
        {
            throw new NotImplementedException();
        }

        public Rules.IGameRules GetRules()
        {
            throw new NotImplementedException();
        }

        public IList<GameObject.Move> GetMoveHistory()
        {
            throw new NotImplementedException();
        }

        public bool NewGame()
        {
            throw new NotImplementedException();
        }

        #region IChessEngine members
         
        public bool RegisterPlayer(int color, IChessPlayer player)
        {
            if (_players.ContainsKey(color))
                return false;

            _players.Add(color, player);
            return true;
        }

        public bool RegisterObserver(IChessObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return true;
        }

        public bool Unregister(IChessObserver entity)
        {
            if (_observers.Contains(entity))
                _observers.Remove(entity);
            if(entity is IChessPlayer)
            {
                int found = -1;
                foreach(var key in _players.Keys)
                {
                    if(_players[key] == entity)
                    {
                        found = key;
                        break;
                    }
                }
                if (found != -1)
                    _players.Remove(found);
            }
            return true;
        }


        protected void ChessGameChanged()
        {
            foreach (var observer in _observers)
                observer.GameUpdated(new GameUpdatedArgs());

            foreach (var player in _players)
                player.Value.GameUpdated(new GameUpdatedArgs());
        }

        #endregion
    }
}
