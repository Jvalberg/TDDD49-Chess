using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Players
{
    public abstract class ChessPlayer : IChessPlayer
    {
        private IChessEngine _chessEngine;

        public ChessPlayer()
        {
            _chessEngine = new ChessEngineLocator().LocateChessEngine();
        }

        public bool RegisterAsPlayer(int color)
        {
            return _chessEngine.RegisterPlayer(color, this);
        }

        public bool RegisterAsObserver()
        {
            return _chessEngine.RegisterObserver(this);
        }

        public bool Unregister()
        {
            return _chessEngine.Unregister(this);
        }

        public virtual void GameUpdated(GameUpdatedArgs args)
        {
        }

        public bool IsGameOver()
        {
            return _chessEngine.IsGameOver();
        }

        public bool IsCurrentTurn(int color)
        {
            return _chessEngine.IsCurrentTurn(color);
        }

        public GameObject.Board GetBoardCopy()
        {
            return _chessEngine.GetBoardCopy();
        }

        public Rules.IGameRules GetRules()
        {
            return _chessEngine.GetRules();
        }

        public IList<GameObject.Move> GetMoveHistory()
        {
            return _chessEngine.GetMoveHistory();
        }

        public bool TryMove(GameObject.Point from, GameObject.Point to)
        {
            return _chessEngine.TryMove(this, from, to);
        }

        public bool NewGame()
        {
            return _chessEngine.NewGame();
        }

        public bool IsActiveGame()
        {
            return _chessEngine.IsActiveGame();
        }

        public bool IsActivePlayer()
        {
            return _chessEngine.IsActivePlayer(this);
        }

    }
}
