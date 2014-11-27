using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.Persistance;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.View.Persistor
{
    public class Persistance : ChessObserver
    {
        public IDataPersistor ChessPersistor { get; set; }
        private String storage_path = "CHESS.xml";

        public Persistance()
        {
            ChessPersistor = new DataPersistor();
            ChessPersistor.AttachPersistor(storage_path);
            ChessPersistor.AutoSyncWithStorage();
            this.RegisterAsObserver();
        }

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.NewGame)
            {
                ChessPersistor.Clear();
            }
            else if(args.Trigger == GameUpdatedTrigger.MovedPiece)
            {
                ChessPersistor.AddState();
            }

        }
    }
}
