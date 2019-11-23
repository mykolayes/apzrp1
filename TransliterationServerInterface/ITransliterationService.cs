using System.Collections.Generic;
using System.ServiceModel;
using Transliteration.DBModels;

namespace Transliteration.Server.Interface
{
    [ServiceContract]
    public interface ITransliterationService
    {
        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        bool UserExists(string login);

        [OperationContract]
        User GetUser(string login);

        [OperationContract]
        void AddTransliteration(Transliteration.DBModels.Transliteration transliteration);

    }

}
