namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDrivingLicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLisence");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLisence", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}