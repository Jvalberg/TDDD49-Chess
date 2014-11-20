using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Players
{
    public class AIChessPlayer : IChessPlayer
    {
        public bool RegisterAsPlayer(int color)
        {
            throw new NotImplementedException();
        }

        public IPlayerChessEngine ChessEngine
        {
            get { throw new NotImplementedException(); }
        }

        public bool RegisterAsObserver()
        {
            throw new NotImplementedException();
        }

        IReadOnlyChessEngine IChessObserver.ChessEngine
        {
            get { throw new NotImplementedException(); }
        }

        public void GameUpdated(GameUpdatedArgs args)
        {
            throw new NotImplementedException();
        }


        public bool Unregister()
        {
            throw new NotImplementedException();
        }
    }
}
