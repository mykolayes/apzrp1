using System.Windows;
using System.Windows.Input;
using Transliteration.Tools;
using Transliteration.Tools.Managers;
using Transliteration.Tools.Navigation;
using Transliteration.TransliterationApplication.Models;

namespace Transliteration.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private Visibility _menuVisibility = Visibility.Collapsed;
        private ICommand _showMenuCommand;
        private ICommand _viewHistoryCommand;
        private ICommand _logOutCommand;
        private ICommand _closeCommand;

        public string CurrentUser
        {
            get
            {
                return $"Current User: {StationManager.CurrentUser}";
            }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            private set
            {
                _menuVisibility = value; 
                OnPropertyChanged();
            }
        }

        public ICommand ShowMenuCommand
        {
            get { return _showMenuCommand ?? (_showMenuCommand = new RelayCommand<object>(ShowMenuImplementation)); }
        }
        public ICommand ViewHistoryCommand
        {
            get { return _viewHistoryCommand ?? (_viewHistoryCommand = new RelayCommand<object>(ViewHistoryImplementation)); }
        }
        public ICommand LogOutCommand
        {
            get { return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutImplementation)); }
        }
        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation)); }
        }

        private void ShowMenuImplementation(object obj)
        {
            MenuVisibility = _menuVisibility==Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ViewHistoryImplementation(object obj)
        {

            NavigationManager.Instance.Navigate(ViewType.History);
        }

        private void LogOutImplementation(object obj)
        {
            StationManager.CurrentLocalUser = new UserLocal();
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
