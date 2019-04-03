namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        Votes = c.String(),
                    })
                .PrimaryKey(t => t.AutoId);
            
            CreateTable(
                "dbo.Votees",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        VoteForId = c.String(),
                        UserName = c.String(),
                        Vote = c.Int(nullable: false),
                        Active = c.String(),
                    })
                .PrimaryKey(t => t.AutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Votees");
            DropTable("dbo.Schools");
        }
    }
}
