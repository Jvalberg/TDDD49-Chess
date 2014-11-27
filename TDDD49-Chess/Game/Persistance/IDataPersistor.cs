using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Persistance
{
    public interface IDataPersistor
    {
        IDataStorageListener DataStorageListener { get; }
        void AddState();
        void Load();
        void Clear();
        void AutoSyncWithStorage();
        /// <summary>
        /// Uses the ChessEngine locator to fetch the current 
        /// ChessEngine
        /// </summary>
        /// <param name="connectionDetails"></param>
        /// <returns></returns>
        bool AttachPersistor(String connectionDetails);
        bool AttachPersistor(String connectionDetails, IChessEngine chessEngine);
        bool IsAttached();
        bool IsAutoSyncing();
    }
}
