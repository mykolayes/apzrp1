using System;
using System.Windows.Controls;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();
            //DataContext = new UserListViewModel();
        }
    }
}
