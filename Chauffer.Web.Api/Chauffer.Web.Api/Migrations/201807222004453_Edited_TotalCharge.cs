namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited_TotalCharge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "TotalCharge", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Bookings", "Charge");
        }

        public override void Down()
        {
            AddColumn("dbo.Bookings", "Charge", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Bookings", "TotalCharge");
        }
    }
}
