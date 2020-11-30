namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedreviewData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        ReviewDescription = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "BookId", "dbo.Book");
            DropIndex("dbo.Review", new[] { "BookId" });
            DropTable("dbo.Review");
        }
    }
}
