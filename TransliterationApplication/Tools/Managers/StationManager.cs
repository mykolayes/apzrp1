using System;
using System.Windows;
using Transliteration.DBModels;
using Transliteration.TransliterationApplication.DataStorage;
using Transliteration.TransliterationApplication.Models;
using Transliteration.TransliterationApplication.TransliterationWCFServerIIS;

namespace Transliteration.Tools.Managers
{
    internal static class StationManager
    {
        public static event Action StopThreads;

        private static TransliterationServiceClient _client;

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static User CurrentUser { get; set; }

        internal static UserLocal CurrentLocalUser { get; set; }

        public static TransliterationServiceClient Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }
            

        internal static void Initialize(TransliterationServiceClient client, IDataStorage dataStorage)
        {
            _client = client;
            _dataStorage = dataStorage;
            CurrentLocalUser = _dataStorage.CurrentUser;
        }
        
        internal static void CloseApp()
        {
            StationManager.DataStorage.ChangeUser(CurrentLocalUser);
            StationManager.DataStorage.SaveCurrentUser();
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
