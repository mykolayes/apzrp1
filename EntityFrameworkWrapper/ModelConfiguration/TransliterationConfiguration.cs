using System.Data.Entity.ModelConfiguration;

namespace Transliteration.EntityFrameworkWrapper.ModelConfiguration
{
    class TransliterationConfiguration : EntityTypeConfiguration<DBModels.Transliteration>
    {
        public TransliterationConfiguration()
        {
            ToTable("Tarnsliteration");
            HasKey(transliter => transliter.Guid);
            Property(transliter => transliter.Guid).HasColumnName("Guid").IsRequired();
            Property(transliter => transliter.RawText).HasColumnName("RawText").IsRequired();
            Property(transliter => transliter.TransliteratedText).HasColumnName("TransliteratedText").IsRequired();
            Property(transliter => transliter.Date).HasColumnName("Date").HasColumnType("datetime2").IsRequired();
            Property(transliter => transliter.UserGuid).HasColumnName("Password").IsRequired();
            //HasIndex(ind => ind.Date).IsUnique(true);
        }

    }
}
