using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Transliteration.DBModels
{
    [DataContract(IsReference = true)]
    public class User
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _email;
        [DataMember]
        private string _login;
        [DataMember]
        private string _password;
        [DataMember]
        private List<Transliteration> _transliterations;

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set { _login = value; }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set { _password = value; }
        }

        public virtual List<Transliteration> Transliterations
        {
            get
            {
                return _transliterations;
            }
            set { _transliterations = value; }
        }

        public User(string firstName, string lastName, string email, string login, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            SetPassword(password);
        }

        public User()
        {
            _transliterations = new List<Transliteration>();
        }

        private void SetPassword(string password)
        {
            _password = password;
        }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
