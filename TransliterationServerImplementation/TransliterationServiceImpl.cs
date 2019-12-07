using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Transliteration.DBModels;
using Transliteration.EntityFrameworkWrapper;
using Transliteration.Server.Interface;

namespace Transliteration.Server.Implementation
{
    public class TransliterationServiceImpl : ITransliterationService
    {
        public void AddTransliteration(DBModels.Transliteration transliteration)
        {
            using (var context = new TransliterationDBContext())
            {
                context.Transliteration.Add(transliteration);
                context.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (var context = new TransliterationDBContext())
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(user.Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                user.Password = System.Text.Encoding.ASCII.GetString(data);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Users.Include(u => u.Transliterations).ToList();
            }
        }

        public User GetUser(string login)
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Users.Where(u => u.Login == login).Include(u => u.Transliterations).FirstOrDefault<User>();
            }
        }

        public bool UserExists(string login)
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Users.Where(u => u.Login == login).ToList().Count != 0;
            }
        }
    }

}
