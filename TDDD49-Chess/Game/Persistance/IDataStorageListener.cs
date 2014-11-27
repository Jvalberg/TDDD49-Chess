using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Persistance
{
    public delegate void DataStorageChangedHandler(Object sender, DataStorageChangedEventArgs e);

    /// <summary>
    /// An object which listens to the specified data storage.
    /// For files either FileSystemWatcher or polling can be used.
    /// http://www.blackwasp.co.uk/FileSystemWatcher.aspx
    /// </summary>
    public interface IDataStorageListener
    {
        event DataStorageChangedHandler DataStorageChanged;
        void ListenTo(String connectionDetails);
    }
}
