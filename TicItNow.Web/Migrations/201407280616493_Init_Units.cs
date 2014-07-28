namespace TicItNow.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Units : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Units");
        }
    }
}
