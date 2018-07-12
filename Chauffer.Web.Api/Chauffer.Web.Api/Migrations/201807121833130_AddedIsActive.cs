namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "IsActive");
        }
    }
}
