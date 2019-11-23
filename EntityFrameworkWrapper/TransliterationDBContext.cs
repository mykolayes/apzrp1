using System.Data.Entity;
using Transliteration.EntityFrameworkWrapper.Migrations;
using Transliteration.EntityFrameworkWrapper.ModelConfiguration;
using Transliteration.DBModels;


namespace Transliteration.EntityFrameworkWrapper
{
    public class TransliterationDBContext : DbContext
    {
        //add correct connStr
         public TransliterationDBContext() : base("DB")
            {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TransliterationDBContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DBModels.Transliteration> Transliteration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new TransliterationConfiguration());
        }
    }

}

