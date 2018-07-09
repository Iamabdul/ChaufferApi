namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCancelledDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CancelledDate", c => c.DateTime());
            AlterColumn("dbo.Bookings", "CompletedDate", c => c.DateTime());
            AlterColumn("dbo.Bookings", "JobType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "JobType", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "CompletedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "CancelledDate");
        }
    }
}
