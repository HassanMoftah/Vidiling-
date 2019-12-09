namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDrivingLicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLisence", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLisence");
        }
    }
}
