using System.IO;
using Transliteration.Tools;
using Transliteration.Tools.Managers;
using Transliteration.TransliterationApplication.Models;

namespace Transliteration.TransliterationApplication.DataStorage
{
    internal class SerializedDataStorage:IDataStorage
    {
        private UserLocal _user;

        internal SerializedDataStorage()
        {
            try
            {
                _user = SerializationManager.Deserialize<UserLocal>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _user = new UserLocal();
                //_user = null;
            }
        }

        public void ChangeUser(UserLocal user)
        {
            _user = user;
        }

        public UserLocal CurrentUser
        {
            get { return _user; }
        }

        public void SaveCurrentUser()
        {
            SerializationManager.Serialize(_user, FileFolderHelper.StorageFilePath);
        }
        
    }
}

