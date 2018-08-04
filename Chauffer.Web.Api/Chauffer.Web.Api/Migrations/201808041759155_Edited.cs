namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "JobType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "JobType", c => c.Int());
        }
    }
}
