using System;
using System.Runtime.Serialization;

namespace Transliteration.DBModels
{
    [DataContract(IsReference = true)]
    public class Transliteration
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _rawText;
        [DataMember]
        private string _transliteratedText;
        [DataMember]
        private DateTime _date;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;

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
        public string RawText
        {
            get
            {
                return _rawText;
            }
            private set
            {
                _rawText = value;
            }
        }
        public string TransliteratedText
        {
            get
            {
                return _transliteratedText;
            }
            private set
            {
                _transliteratedText = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set { _date = value; }
        }
        public Guid UserGuid
        {
            get
            {
                return _userGuid;
            }
            set { _userGuid = value; }
        }


        public User User
        {
            get
            {
                return _user;
            }
            set { _user = value; }
        }

        public Transliteration(string rawText, string transliteratedText, DateTime date) : this()
        {
            _guid = Guid.NewGuid();
            _rawText = rawText;
            _transliteratedText = transliteratedText;
            _date = date;
        }

        public Transliteration()
        {
            
        }

        public override string ToString()
        {
            return  _transliteratedText;
        }
    }
}
