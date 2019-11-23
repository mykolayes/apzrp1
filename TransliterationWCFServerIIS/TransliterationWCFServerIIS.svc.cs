using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Transliteration.DBModels;
using Transliteration.Server.Implementation;
using Transliteration.Server.Interface;

namespace Transliteration.TransliterationWCFServerIIS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF  Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TransliterationWCFServerIIS : ITransliterationService
    {
        private TransliterationServiceImpl service = new TransliterationServiceImpl();
        public void AddTransliteration(DBModels.Transliteration transliteration)
        {
            service.AddTransliteration(transliteration);
        }

        public void AddUser(User user)
        {
            service.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return service.GetAllUsers();
        }

        public User GetUser(string login)
        {
            return service.GetUser(login);
        }

        public bool UserExists(string login)
        {
            return service.UserExists(login);
        }
    }
}
