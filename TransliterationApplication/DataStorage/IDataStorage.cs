using Transliteration.TransliterationApplication.Models;

namespace Transliteration.TransliterationApplication.DataStorage
{
    internal interface IDataStorage
    {
        void ChangeUser(UserLocal user);
        void SaveCurrentUser();
        UserLocal CurrentUser { get; }
    }
}
