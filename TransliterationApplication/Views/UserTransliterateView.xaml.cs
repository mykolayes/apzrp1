using System.Windows.Controls;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Interaction logic for UserTransliterateView.xaml
    /// </summary>
    public partial class UserTransliterateView : UserControl
    {
        public UserTransliterateView()
        {
            InitializeComponent();
            DataContext = new UserTransliterateViewModel();
        }
    }
}
