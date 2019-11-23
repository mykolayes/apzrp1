using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Transliteration.DBModels;
using Transliteration.Properties;
using Transliteration.Tools;
using Transliteration.Tools.Managers;
using System.Text;

namespace Transliteration.ViewModels
{
    class UserTransliterateViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _textToBeTransliterated;
        private string _transliteratedText;
        #endregion

        #region Commands
        private ICommand _transliterateCommand;
        #endregion


        #region Properties
        public string TextToBeTransliterated
        {
            get { return _textToBeTransliterated; }
            set
            {
                _textToBeTransliterated = value;
                OnPropertyChanged();
            }
        }

        public string TransliteratedText
        {
            get { return _transliteratedText; }
            set
            {
                _transliteratedText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand TransliterateCommand
        {
            get
            {
                return _transliterateCommand ?? (_transliterateCommand =
                           new RelayCommand<object>(TransliterateImplementation));
            }
        }
        #endregion

        private async void TransliterateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    TransliteratedText = Transliterate();
                    var transliteration = new DBModels.Transliteration(TextToBeTransliterated, TransliteratedText, DateTime.Now);
                    transliteration.UserGuid = StationManager.CurrentUser.Guid;
                    StationManager.CurrentUser.Transliterations.Add(transliteration);
                    StationManager.Client.AddTransliteration(transliteration);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Transliteration failed. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string Transliterate()
        {
            var sb = new StringBuilder(TextToBeTransliterated.Length*2);

            for (var i = 0; i < TextToBeTransliterated.Length; i++)
            {
                var c = TextToBeTransliterated[i];
                switch (c)
                {
                    case 'Є':
                        sb.Append('Y');
                        sb.Append('e');
                        break;
                    case 'Ї':
                        sb.Append('Y');
                        sb.Append('i');
                        break;
                    case 'А':
                        sb.Append('A');
                        break;
                    case 'Б':
                        sb.Append('B');
                        break;
                    case 'В':
                        sb.Append('V');
                        break;
                    case 'Г':
                        sb.Append('H');
                        break;
                    case 'Д':
                        sb.Append('D');
                        break;
                    case 'Е':
                        sb.Append('E');
                        break;
                    case 'Ж':
                        sb.Append('Z');
                        sb.Append('h');
                        break;
                    case 'З':
                        sb.Append('Z');
                        break;
                    case 'И':
                        sb.Append('Y');
                        sb.Append('`');
                        break;
                    case 'Й':
                        sb.Append('J');
                        break;
                    case 'К':
                        sb.Append('K');
                        break;
                    case 'Л':
                        sb.Append('L');
                        break;
                    case 'М':
                        sb.Append('M');
                        break;
                    case 'Н':
                        sb.Append('N');
                        break;
                    case 'О':
                        sb.Append('O');
                        break;
                    case 'П':
                        sb.Append('P');
                        break;
                    case 'Р':
                        sb.Append('R');
                        break;
                    case 'С':
                        sb.Append('S');
                        break;
                    case 'Т':
                        sb.Append('T');
                        break;
                    case 'У':
                        sb.Append('U');
                        break;
                    case 'Ф':
                        sb.Append('F');
                        break;
                    case 'Х':
                        sb.Append('X');
                        break;
                    case 'Ц':
                        sb.Append('T');
                        sb.Append('s');
                        break;
                    case 'Ч':
                        sb.Append('C');
                        sb.Append('h');
                        break;
                    case 'Ш':
                        sb.Append('S');
                        sb.Append('h');
                        break;
                    case 'Щ':
                        sb.Append('S');
                        sb.Append('h');
                        sb.Append('c');
                        sb.Append('h');
                        break;
                    case 'Ь':
                        sb.Append('`');
                        break;
                    case 'Ю':
                        sb.Append('Y');
                        sb.Append('u');
                        break;
                    case 'Я':
                        sb.Append('Y');
                        sb.Append('a');
                        break;
                    case 'а':
                        sb.Append('a');
                        break;
                    case 'б':
                        sb.Append('b');
                        break;
                    case 'в':
                        sb.Append('v');
                        break;
                    case 'г':
                        sb.Append('h');
                        break;
                    case 'д':
                        sb.Append('d');
                        break;
                    case 'е':
                        sb.Append('e');
                        break;
                    case 'ж':
                        sb.Append('z');
                        sb.Append('h');
                        break;
                    case 'з':
                        sb.Append('z');
                        break;
                    case 'и':
                        sb.Append('y');
                        break;
                    case 'й':
                        sb.Append('j');
                        break;
                    case 'к':
                        sb.Append('k');
                        break;
                    case 'л':
                        sb.Append('l');
                        break;
                    case 'м':
                        sb.Append('m');
                        break;
                    case 'н':
                        sb.Append('n');
                        break;
                    case 'о':
                        sb.Append('o');
                        break;
                    case 'п':
                        sb.Append('p');
                        break;
                    case 'р':
                        sb.Append('r');
                        break;
                    case 'с':
                        sb.Append('s');
                        break;
                    case 'т':
                        sb.Append('t');
                        break;
                    case 'у':
                        sb.Append('u');
                        break;
                    case 'ф':
                        sb.Append('f');
                        break;
                    case 'х':
                        sb.Append('x');
                        break;
                    case 'ц':
                        sb.Append('t');
                        sb.Append('s');
                        break;
                    case 'ч':
                        sb.Append('c');
                        sb.Append('h');
                        break;
                    case 'ш':
                        sb.Append('s');
                        sb.Append('h');
                        break;
                    case 'щ':
                        sb.Append('s');
                        sb.Append('h');
                        sb.Append('c');
                        sb.Append('h');
                        break;
                    case 'ь':
                        sb.Append('`');
                        break;
                    case 'ю':
                        sb.Append('y');
                        sb.Append('u');
                        break;
                    case 'я':
                        sb.Append('y');
                        sb.Append('a');
                        break;
                    case 'є':
                        sb.Append('i');
                        sb.Append('e');
                        break;
                    case 'ї':
                        sb.Append('i');
                        break;
                    case 'Ґ':
                        sb.Append('G');
                        break;
                    case 'ґ':
                        sb.Append('g');
                        break;
                    case '’':
                        sb.Append('\'');
                        break;
                    default:
                        sb.Append(c);
                        break;
                }

            }
            return sb.ToString();
        }
    }
}
