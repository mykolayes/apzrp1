using System;

namespace Transliteration.TransliterationApplication.Models
{
    [Serializable]
    internal class UserLocal
    {
        #region Fields
        private string _login;
        private string _password;
        #endregion

        #region Properties
        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
        }
        #endregion

        #region Constructors
        public UserLocal(string login, string password) //, string password
        {
            _login = login;
            SetPassword(password);
        }

        public UserLocal()
        {
            _login = "";
            _password = "";
        }
        #endregion

        private void SetPassword(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            var hash = System.Text.Encoding.ASCII.GetString(data);
            _password = hash;
        }
    }
}
