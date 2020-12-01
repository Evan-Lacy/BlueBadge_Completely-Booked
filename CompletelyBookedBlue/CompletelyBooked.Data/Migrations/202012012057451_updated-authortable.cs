namespace CompletelyBooked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedauthortable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Author", "Birthday", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Author", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
