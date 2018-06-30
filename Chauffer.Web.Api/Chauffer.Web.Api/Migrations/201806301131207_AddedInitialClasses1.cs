namespace Chauffer.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInitialClasses1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(),
                        DriverId = c.String(),
                        StartAddress = c.String(),
                        StartPostCode = c.String(),
                        EndAddress = c.String(),
                        EndPostCode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CompletedDate = c.DateTime(nullable: false),
                        JobType = c.Int(nullable: false),
                        ExtraInformation = c.String(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PreferredName = c.String(),
                        PreferredDriverUserId = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        PhoneNumber_Telephone = c.String(),
                        PhoneNumber_MobilePhone = c.String(),
                        PhoneNumber_OfficePhone = c.String(),
                        ExtraInformation = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PreferredName = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        PhoneNumber_Telephone = c.String(),
                        PhoneNumber_MobilePhone = c.String(),
                        PhoneNumber_OfficePhone = c.String(),
                        LiscenceNumber = c.String(),
                        CarType = c.Int(nullable: false),
                        CarDetails = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        StopId = c.String(nullable: false, maxLength: 128),
                        BookingId = c.String(),
                        StopAddress = c.String(),
                        StopPostCode = c.String(),
                        StopReason = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StopId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stops");
            DropTable("dbo.Drivers");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
