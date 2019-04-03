namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        OutDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ImageUrl = c.String(),
                        Branche = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
