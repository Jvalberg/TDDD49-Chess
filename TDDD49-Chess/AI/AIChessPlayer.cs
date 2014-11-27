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

        public AIChessPlayer()
        {
            random = new Random();
            _color = Color.NONE;
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
                            tryMakeMove();
                        }
                    }
                }
            }
        }

        private void tryMakeMove()
        {
            var board = this.GetBoardCopy();
            var pieces = board.GetAllPieces(_color);
            bool successful = false;
            do
            {
                var rndPiece = random.Next(pieces.Count);
                if (rndPiece >= 0 && rndPiece < pieces.Count && pieces.Count > 0)
                {
                    var validMoves = this.GetRules().MovementRules.ValidMoves(board, pieces[rndPiece]);
                    var rndMove = random.Next(validMoves.Count);
                    if (rndMove >= 0 && rndMove < validMoves.Count && validMoves.Count > 0)
                    {
                        successful = this.TryMove(pieces[rndPiece], validMoves[rndMove]);
                    }
                }
            } while (!successful);
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
