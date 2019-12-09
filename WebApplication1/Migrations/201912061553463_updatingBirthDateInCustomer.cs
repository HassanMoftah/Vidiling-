namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingBirthDateInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.String());
        }
    }
}
