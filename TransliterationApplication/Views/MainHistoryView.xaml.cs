using System.Windows.Controls;
using Transliteration.Tools.Navigation;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    public partial class MainHistoryView : UserControl, INavigatable
    {
        public MainHistoryView()
        {
            InitializeComponent();
            DataContext = new MainHistoryViewModel(); 
        }
    }
}
