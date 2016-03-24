using System;
using System.Data.Entity.Migrations;

namespace ApplicationMVC.Data.Migrations
{
    // This class was created by typing "Add-Migration InitialCreate" in the Package Manager Console. It can be modified if needed.
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestEntities");
        }
    }
}
