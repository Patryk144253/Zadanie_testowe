namespace ZAdanie_testowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Przejsciowas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RezerwacjaId = c.Int(nullable: false),
                        GoscId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goscs", t => t.GoscId, cascadeDelete: true)
                .ForeignKey("dbo.Rezerwacjas", t => t.RezerwacjaId, cascadeDelete: true)
                .Index(t => t.RezerwacjaId)
                .Index(t => t.GoscId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Przejsciowas", "RezerwacjaId", "dbo.Rezerwacjas");
            DropForeignKey("dbo.Przejsciowas", "GoscId", "dbo.Goscs");
            DropIndex("dbo.Przejsciowas", new[] { "GoscId" });
            DropIndex("dbo.Przejsciowas", new[] { "RezerwacjaId" });
            DropTable("dbo.Przejsciowas");
        }
    }
}
