namespace Transliteration.EntityFrameworkWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarnsliteration",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        RawText = c.String(nullable: false),
                        TransliteratedText = c.String(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Password = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.User", t => t.Password, cascadeDelete: true)
                .Index(t => t.Password);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarnsliteration", "Password", "dbo.User");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.Tarnsliteration", new[] { "Password" });
            DropTable("dbo.User");
            DropTable("dbo.Tarnsliteration");
        }
    }
}
