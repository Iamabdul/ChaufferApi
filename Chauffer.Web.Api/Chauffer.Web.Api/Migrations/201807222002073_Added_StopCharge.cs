namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_StopCharge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "Charge", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.Bookings", "Charge");
        }
    }
}
