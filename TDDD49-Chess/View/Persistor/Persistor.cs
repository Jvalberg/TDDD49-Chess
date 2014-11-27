using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDD49_Chess.Game.Persistance;
using TDDD49_Chess.Game.Players;

namespace TDDD49_Chess.View.Persistor
{
    public class Persistor : ChessObserver
    {
        private IDataPersistor _chessPersister;
        private String storage_path = "CHESS.xml";

        public Persistor()
        {
            _chessPersister = new DataPersistor();
            _chessPersister.AttachPersistor(storage_path);
            _chessPersister.AutoSyncWithStorage();
            this.RegisterAsObserver();
            _chessPersister.Load();
        }

        public override void GameUpdated(GameUpdatedArgs args)
        {
            if(args.Trigger == GameUpdatedTrigger.NewGame)
            {
                _chessPersister.Clear();
            }
            else if(args.Trigger == GameUpdatedTrigger.MovedPiece)
            {
                _chessPersister.AddState();
            }

        }
    }
}
