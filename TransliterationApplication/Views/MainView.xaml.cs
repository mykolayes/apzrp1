using System.Windows.Controls;
using Transliteration.Tools.Navigation;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); 
        }
    }
}
