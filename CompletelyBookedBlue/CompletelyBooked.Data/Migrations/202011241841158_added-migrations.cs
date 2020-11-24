namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Birthplace = c.String(nullable: false),
                        About = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(),
                        YearFounded = c.Int(nullable: false),
                        BestSellerCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            AddColumn("dbo.Book", "Publisher_PublisherId", c => c.Int());
            CreateIndex("dbo.Book", "Publisher_PublisherId");
            AddForeignKey("dbo.Book", "Publisher_PublisherId", "dbo.Publisher", "PublisherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Publisher_PublisherId", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "Publisher_PublisherId" });
            DropColumn("dbo.Book", "Publisher_PublisherId");
            DropTable("dbo.Publisher");
            DropTable("dbo.Author");
        }
    }
}
