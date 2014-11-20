using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.Test.MockObjects
{
    public class TestListener : IChessPlayer
    {
        public Boolean Triggered { get; set; }

        public bool RegisterAsObserver()
        {
            throw new NotImplementedException();
        }

        public bool Unregister()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyChessEngine ChessEngine
        {
            get { throw new NotImplementedException(); }
        }

        public void GameUpdated(GameUpdatedArgs args)
        {
            Triggered = true;
        }

        public bool RegisterAsPlayer(int color)
        {
            throw new NotImplementedException();
        }

        IPlayerChessEngine IChessPlayer.ChessEngine
        {
            get { throw new NotImplementedException(); }
        }
    }
}
