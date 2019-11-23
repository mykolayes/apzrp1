using System.Windows.Controls;
using Transliteration.Tools.Navigation;
using Transliteration.ViewModels.Authentication;

namespace Transliteration.Views.Authentication
{
    public partial class SignUpView : UserControl, INavigatable
    {
        internal SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
