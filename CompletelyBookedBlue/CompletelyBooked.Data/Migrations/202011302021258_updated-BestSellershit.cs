namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedBestSellershit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Publisher", "BestSellerCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publisher", "BestSellerCount", c => c.Int(nullable: false));
        }
    }
}
