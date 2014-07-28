namespace TicItNow.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalysisParams",
                c => new
                    {
                        AnalysisParamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinValue = c.Int(),
                        MaxValue = c.Int(),
                        UnitId = c.Int(),
                        SymbolId = c.Int(),
                    })
                .PrimaryKey(t => t.AnalysisParamId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.Symbols", t => t.SymbolId)
                .Index(t => t.UnitId)
                .Index(t => t.SymbolId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AnalysisParams", new[] { "SymbolId" });
            DropIndex("dbo.AnalysisParams", new[] { "UnitId" });
            DropForeignKey("dbo.AnalysisParams", "SymbolId", "dbo.Symbols");
            DropForeignKey("dbo.AnalysisParams", "UnitId", "dbo.Units");
            DropTable("dbo.AnalysisParams");
        }
    }
}
