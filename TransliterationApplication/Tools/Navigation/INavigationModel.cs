namespace Transliteration.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        Main,
        History
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
