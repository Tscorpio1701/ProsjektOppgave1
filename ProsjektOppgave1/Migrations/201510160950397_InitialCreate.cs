namespace ProsjektOppgave1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bestilling",
                c => new
                    {
                        BestillingID = c.Int(nullable: false, identity: true),
                        OrdreDato = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dbKunde_ID = c.Int(),
                    })
                .PrimaryKey(t => t.BestillingID)
                .ForeignKey("dbo.dbKunde", t => t.dbKunde_ID)
                .Index(t => t.dbKunde_ID);
            
            CreateTable(
                "dbo.Vare",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Varenavn = c.String(),
                        Pris = c.Int(nullable: false),
                        Varebeholdning = c.Int(nullable: false),
                        Bestilling_BestillingID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bestilling", t => t.Bestilling_BestillingID)
                .Index(t => t.Bestilling_BestillingID);
            
            CreateTable(
                "dbo.dbKunde",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        Etternavn = c.String(),
                        Adresse = c.String(),
                        Passord = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bestilling", "dbKunde_ID", "dbo.dbKunde");
            DropForeignKey("dbo.Vare", "Bestilling_BestillingID", "dbo.Bestilling");
            DropIndex("dbo.Vare", new[] { "Bestilling_BestillingID" });
            DropIndex("dbo.Bestilling", new[] { "dbKunde_ID" });
            DropTable("dbo.dbKunde");
            DropTable("dbo.Vare");
            DropTable("dbo.Bestilling");
        }
    }
}
