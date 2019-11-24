using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transliteration.TransliterationApplication.Models
{
    [Serializable]
    internal class UserLocal
    {
        #region Fields
        private string _login;
        //private string _password;
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
        //private string Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //}
        #endregion

        #region Constructors
        public UserLocal(string login) //, string password
        {
            _login = login;
            //_password = password;
            //SetPassword(password);
        }

        public UserLocal()
        {
            _login = "";
            //_password = "";
            //SetPassword(password);
        }
        #endregion

        //private void SetPassword(string password)
        //{
        //    //TODO Add encryption
        //    _password = password;
        //}
    }
}
