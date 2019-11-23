using System.Data.Entity.Migrations;

namespace Transliteration.EntityFrameworkWrapper.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TransliterationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TransliterationDBContext context)
        {

        }
    }
}
