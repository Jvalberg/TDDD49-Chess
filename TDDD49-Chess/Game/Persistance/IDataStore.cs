using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Persistance
{
    public interface IDataStore
    {
        void Clear();
        void AddState(IChessEngine chessEngine);
        void Load(IChessEngine chessEngine);

        void AddMetadata(String identifier, String value);
        String GetMetadata(String identifier);

        /// <summary>
        /// Ensures that the datastore exists (and is intact).
        /// </summary>
        /// <param name="connectionDetails"></param>
        void SetupDataStore(String connectionDetails);
    }
}
