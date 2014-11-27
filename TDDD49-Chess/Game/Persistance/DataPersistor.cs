using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDD49_Chess.Game.Persistance
{
    public class DataPersistor : IDataPersistor
    {
        private Boolean _isAttached;
        private Boolean _isAutoSyncing;
        private String _connectionDetails;
        private IDataStore _dataStore;
        private IChessEngine _chessEngine;

        private IDataStorageListener _dataStorageListener;
        public IDataStorageListener DataStorageListener
        {
            get { return _dataStorageListener; }
        }

        private bool _performedRecentDataStorageChange = false;


        public DataPersistor()
        {
            Reset();
        }

        private void Reset()
        {
            _isAttached = false;
            _isAutoSyncing = false;
            _connectionDetails = "";
            _dataStore = new DataStore();
            _chessEngine = null;
            if (_dataStorageListener != null)
                _dataStorageListener.DataStorageChanged -= _dataStorageListener_DataStorageChanged;
            _dataStorageListener = new DataStorageListener();
            _performedRecentDataStorageChange = false;
        }

        public bool AttachPersistor(string connectionDetails)
        {
            return AttachPersistor(connectionDetails, new ChessEngineLocator().LocateChessEngine());
        }

        public bool AttachPersistor(string connectionDetails, IChessEngine chessEngine)
        {
            if (chessEngine == null)
            {
                Reset();
                return false;
            }
            _dataStore.SetupDataStore(connectionDetails);
            _chessEngine = chessEngine;
            _isAttached = true;
            _connectionDetails = connectionDetails;
            _performedRecentDataStorageChange = false;
            return true;
        }

        public bool IsAttached()
        {
            return _isAttached;
        }

        public void AddState()
        {
            if(_isAttached)
            {
                try
                {
                    _performedRecentDataStorageChange = true;
                    _dataStore.AddState(_chessEngine);
                    
                }
                catch(Exception e)
                {

                }
            }
        }

        public void Load()
        {
            if(_isAttached)
            {
                try
                {
                    _dataStore.Load(_chessEngine);
                }
                catch(Exception e)
                {

                }
            }
        }

        public void Clear()
        {
            if(_isAttached)
            {
                try
                {
                    _performedRecentDataStorageChange = true;
                    _dataStore.Clear();
                }
                catch(Exception e)
                {

                }
            }
        }

        public void AutoSyncWithStorage()
        {
            if (_isAttached)
            {
                _isAutoSyncing = true;
                _dataStorageListener.ListenTo(_connectionDetails);
                _dataStorageListener.DataStorageChanged += _dataStorageListener_DataStorageChanged;
            }
            else
                throw new Exception("Cannot automatically sync with a storage if not attached to one.");
        }

        public bool IsAutoSyncing()
        {
            return _isAutoSyncing;
        }

        void _dataStorageListener_DataStorageChanged(object sender, DataStorageChangedEventArgs e)
        {
            if (!_performedRecentDataStorageChange)
            {
                _dataStore.Load(_chessEngine);
            }
            _performedRecentDataStorageChange = false;
        }

    }
}
