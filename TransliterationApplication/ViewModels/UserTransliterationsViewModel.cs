using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Transliteration.Properties;
using Transliteration.Tools.Managers;

namespace Transliteration.ViewModels
{
    class UserTransliterationsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DBModels.Transliteration> _transliterations;

        public ObservableCollection<DBModels.Transliteration> Transliterations
        {
            get => _transliterations;
            private set
            {
                _transliterations = value;
                OnPropertyChanged();
            }
        }

        internal UserTransliterationsViewModel()
        {
            Transliterations = new ObservableCollection<DBModels.Transliteration>(StationManager.CurrentUser.Transliterations);        
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
