namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty : DbMigration
    {
        public override void Up()
        {
            Sql("delete  customers");
        }
        
        public override void Down()
        {
        }
    }
}
