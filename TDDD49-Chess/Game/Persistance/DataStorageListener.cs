using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TDDD49_Chess.Game.Persistance
{

    public class DataStorageListener : IDataStorageListener
    {
        private FileSystemWatcher _fileSystemWatcher;
        private String _fileToWatch;

        public static String AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public DataStorageListener()
        {
        }

        public event DataStorageChangedHandler DataStorageChanged;

        public void ListenTo(string connectionDetails)
        {
            _fileToWatch = connectionDetails;
            try
            {
                _fileSystemWatcher = new FileSystemWatcher();
                _fileSystemWatcher.Path = AssemblyDirectory;
                _fileSystemWatcher.EnableRaisingEvents = true;
                _fileSystemWatcher.Filter = "*.xml";
                _fileSystemWatcher.Changed += _fileSystemWatcher_Changed;
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// The reason i use a count here is because of the complexity of the operations required to store files and stuff like that
        /// FileSystemWatcher always triggers two events when i changed the file in note pad, which is why the
        /// count ugly hack is here right now.
        /// </summary>
        private int count = 0;
        private void _fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            count++;
            if(e.Name == _fileToWatch && e.ChangeType == WatcherChangeTypes.Changed && count == 2)
            {
                count = 0;
                Application.Current.Dispatcher.Invoke(new Action(() => OnDataStorageChanged(new DataStorageChangedEventArgs())));
            }
        }

        private void OnDataStorageChanged(DataStorageChangedEventArgs e)
        {
            var handler = DataStorageChanged;
            if(handler != null)
            {
                handler(this, e);
            }
        }


        public void PausListening()
        {
            if (_fileSystemWatcher != null)
                _fileSystemWatcher.EnableRaisingEvents = false;
        }

        public void ResumeListening()
        {
            if (_fileSystemWatcher != null)
                _fileSystemWatcher.EnableRaisingEvents = true;
        }
    }
}
