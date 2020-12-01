namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReviewTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Review", "ReviewDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Review", "ReviewDescription", c => c.String());
        }
    }
}
