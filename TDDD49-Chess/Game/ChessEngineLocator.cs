using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game
{
    public class ChessEngineLocator
    {
        private static IChessEngine _chessEngine;

        /// <summary>
        /// An ugly singleton implementation only here because of the lab constraints.
        /// </summary>
        /// <returns></returns>
        public IChessEngine LocateChessEngine()
        {
            if (_chessEngine == null)
                _chessEngine = new ChessEngine();

            return _chessEngine;
        }
    }
}
