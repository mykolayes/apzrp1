using System.Windows.Controls;
using Transliteration.Tools.Navigation;
using Transliteration.ViewModels.Authentication;

namespace Transliteration.Views.Authentication
{
    public partial class SignInView : UserControl,INavigatable
    {
        internal SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
