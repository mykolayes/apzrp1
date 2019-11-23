using System;
using System.Windows;
using Transliteration.DBModels;
using Transliteration.TransliterationApplication.TransliterationWCFServerIIS;

namespace Transliteration.Tools.Managers
{
    internal static class StationManager
    {
        public static event Action StopThreads;

        private static TransliterationServiceClient _client;

        internal static User CurrentUser { get; set; }

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
            

        internal static void Initialize(TransliterationServiceClient client)
        {
            _client = client;
        }
        
        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            //TODO serialize user's login/psw to local datastorage
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
