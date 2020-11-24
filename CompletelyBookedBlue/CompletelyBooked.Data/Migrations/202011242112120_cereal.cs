namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cereal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "Publisher_PublisherId", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "Publisher_PublisherId" });
            RenameColumn(table: "dbo.Book", name: "Publisher_PublisherId", newName: "PublisherId");
            AddColumn("dbo.Book", "BookPublisher", c => c.String(nullable: false));
            AlterColumn("dbo.Book", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "PublisherId");
            AddForeignKey("dbo.Book", "PublisherId", "dbo.Publisher", "PublisherId", cascadeDelete: true);
            DropColumn("dbo.Book", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Publisher", c => c.String(nullable: false));
            DropForeignKey("dbo.Book", "PublisherId", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "PublisherId" });
            AlterColumn("dbo.Book", "PublisherId", c => c.Int());
            DropColumn("dbo.Book", "BookPublisher");
            RenameColumn(table: "dbo.Book", name: "PublisherId", newName: "Publisher_PublisherId");
            CreateIndex("dbo.Book", "Publisher_PublisherId");
            AddForeignKey("dbo.Book", "Publisher_PublisherId", "dbo.Publisher", "PublisherId");
        }
    }
}
