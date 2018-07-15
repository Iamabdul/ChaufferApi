namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_LastBookingDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "LicenceNumber", c => c.String());
            AddColumn("dbo.Drivers", "LastBookingDate", c => c.DateTime());
            DropColumn("dbo.Drivers", "LiscenceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "LiscenceNumber", c => c.String());
            DropColumn("dbo.Drivers", "LastBookingDate");
            DropColumn("dbo.Drivers", "LicenceNumber");
        }
    }
}
