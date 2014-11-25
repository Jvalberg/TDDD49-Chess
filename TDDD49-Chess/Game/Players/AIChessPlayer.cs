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

        public bool RegisterAsObserver()
        {
            throw new NotImplementedException();
        }

        public bool Unregister()
        {
            throw new NotImplementedException();
        }

        public void GameUpdated(GameUpdatedArgs args)
        {
            throw new NotImplementedException();
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

        public bool TryMove(GameObject.Point from, GameObject.Point to)
        {
            throw new NotImplementedException();
        }

        public bool NewGame()
        {
            throw new NotImplementedException();
        }

        public bool IsActiveGame()
        {
            throw new NotImplementedException();
        }
    }
}
