namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_StartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "StartDate");
        }
    }
}
