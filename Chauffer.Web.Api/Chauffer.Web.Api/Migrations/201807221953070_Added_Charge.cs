namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Charge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Charge", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stops", "Address", c => c.String());
            AddColumn("dbo.Stops", "PostCode", c => c.String());
            AddColumn("dbo.Stops", "Reason", c => c.Int(nullable: false));
            DropColumn("dbo.Stops", "StopAddress");
            DropColumn("dbo.Stops", "StopPostCode");
            DropColumn("dbo.Stops", "StopReason");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stops", "StopReason", c => c.Int(nullable: false));
            AddColumn("dbo.Stops", "StopPostCode", c => c.String());
            AddColumn("dbo.Stops", "StopAddress", c => c.String());
            DropColumn("dbo.Stops", "Reason");
            DropColumn("dbo.Stops", "PostCode");
            DropColumn("dbo.Stops", "Address");
            DropColumn("dbo.Bookings", "Charge");
        }
    }
}
