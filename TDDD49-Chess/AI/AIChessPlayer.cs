using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.GameObject;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.AI
{
    public class AIChessPlayer : ChessPlayer, IAIChessPlayer
    {
        private int _color;
        private Random random;

        private IChessMoveAlgorithm _moveAlgorithm;

        public AIChessPlayer()
        {
            random = new Random();
            _color = Color.NONE;
            //_moveAlgorithm = new ChessRandomMoveAlgorithm(this);
            _moveAlgorithm = new ChessMinimaxMoveAlgorithm(this);
        }

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.BoardLoaded ||
                args.Trigger == GameUpdatedTrigger.MovedPiece || 
                args.Trigger == GameUpdatedTrigger.NewGame || 
                args.Trigger == GameUpdatedTrigger.PlayerAdded)
            {
                if (this.IsActiveGame())
                {
                    if (!this.IsGameOver())
                    {
                        if (this.IsCurrentTurn(_color))
                        {
                            var move = _moveAlgorithm.GetNextMove(this.GetBoardCopy(), this._color);
                            if(move != null)
                            {
                                this.TryMove(move.Item1, move.Item2);
                            }
                        }
                    }
                }
            }
        }


        public void AddAI()
        {
            _color = Color.BLACK; //Tries the black color first.
            bool successful = this.RegisterAsPlayer(_color);
            if(!successful)
            {
                _color = Color.WHITE;
                successful = this.RegisterAsPlayer(_color);
            }

            if(!successful)
            {
                throw new Exception("AI Player could not register to the current chess game.");
            }
        }

        public void Dispose()
        {
            this.Unregister();
            //Remove resources.
        }


        public bool IsActive()
        {
            return this.IsActivePlayer();
        }
    }
}
