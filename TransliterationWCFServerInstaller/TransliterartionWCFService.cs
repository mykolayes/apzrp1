using System;
using System.ServiceModel;
using System.ServiceProcess;
using Transliteration.Server.Implementation;

namespace Transliteration.TransliterationWCFServerInstaller
{
    partial class TransliterationWCFService : ServiceBase
    {
        internal const string CurrentServiceName = "TransliterationService";
        internal const string CurrentServiceDisplayName = "Transliteration Service";
        internal const string CurrentServiceSource = "TransliterationSource";
        internal const string CurrentServiceLogName = "TransliterationServiceLogName";
        internal const string CurrentServiceDescription = "Transliteration";
        private ServiceHost _serviceHost = null;

        public TransliterationWCFService()
        {
            InitializeComponent();
            ServiceName = CurrentServiceName;
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            RequestAdditionalTime(120 * 1000);
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(1000);
            //}
#endif
            _serviceHost?.Close();
            try
            {
                _serviceHost = new ServiceHost(typeof(TransliterationServiceImpl));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                //TODO implement Logging
                throw;
            }
        }

        protected override void OnStop()
        {
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                //TODO add Logging
            }
        }
    }
}
