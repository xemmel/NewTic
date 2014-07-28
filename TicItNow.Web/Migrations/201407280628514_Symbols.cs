namespace TicItNow.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Symbols : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Symbols",
                c => new
                    {
                        SymbolId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SymbolId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Symbols");
        }
    }
}
