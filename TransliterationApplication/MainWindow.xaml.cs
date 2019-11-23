using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Transliteration.Tools.Managers;
using Transliteration.Tools.Navigation;
using Transliteration.ViewModels;
using Transliteration.TransliterationApplication.TransliterationWCFServerIIS;

namespace Transliteration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IContentOwner
    {
        public ContentControl ContentControl {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            TransliterationServiceClient serverClient = new TransliterationServiceClient("BasicHttpBinding_ITransliterationService");

            StationManager.Initialize(serverClient);
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            StationManager.CloseApp();
        }
    }
}
