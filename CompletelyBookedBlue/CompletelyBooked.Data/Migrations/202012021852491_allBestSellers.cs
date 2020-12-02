namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allBestSellers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Book", "Book_BookId");
            AddForeignKey("dbo.Book", "Book_BookId", "dbo.Book", "BookId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Book_BookId", "dbo.Book");
            DropIndex("dbo.Book", new[] { "Book_BookId" });
            DropColumn("dbo.Book", "Book_BookId");
        }
    }
}
