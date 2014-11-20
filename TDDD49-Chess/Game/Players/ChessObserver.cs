using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Players
{
    public class ChessObserver : IChessObserver
    {
        public bool RegisterAsObserver()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyChessEngine ChessEngine
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
