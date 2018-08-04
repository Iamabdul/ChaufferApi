namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stops", "Date");
        }
    }
}
