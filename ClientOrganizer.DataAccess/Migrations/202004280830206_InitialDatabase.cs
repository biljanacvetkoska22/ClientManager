namespace ClientOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        PartyId = c.Int(nullable: false),
                        PartyCode = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        TaxCode = c.Long(nullable: false),
                        CountryCode = c.String(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, storeType: "date"),
                        ClientType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PartyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Client");
        }
    }
}
