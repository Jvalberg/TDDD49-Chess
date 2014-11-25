using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Players
{
    public abstract class ChessObserver : IChessObserver
    {
        private IChessEngine _chessEngine;

        public ChessObserver()
        {
            _chessEngine = new ChessEngineLocator().LocateChessEngine();
        }

        public bool RegisterAsObserver()
        {
            return _chessEngine.RegisterObserver(this);
        }

        public bool Unregister()
        {
            return _chessEngine.Unregister(this);
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

        public bool IsActiveGame()
        {
            return _chessEngine.IsActiveGame();
        }

        public abstract void GameUpdated(GameUpdatedArgs args);
    }
}
