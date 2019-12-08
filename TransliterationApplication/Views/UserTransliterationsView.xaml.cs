using System.Windows.Controls;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Interaction logic for UserTransliterationsView.xaml
    /// </summary>
    public partial class UserTransliterationsView : UserControl
    {
        public UserTransliterationsView()
        {
            InitializeComponent();
            DataContext = new UserTransliterationsViewModel();
        }
    }
}
