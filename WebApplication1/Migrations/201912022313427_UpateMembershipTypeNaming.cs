namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpateMembershipTypeNaming : DbMigration
    {
        public override void Up()
        {
            Sql("update membershiptypes set name='Pay As You GO' where id=0");
            Sql("update membershiptypes set name='Monthly' where id=1");
            Sql("update membershiptypes set name='Quarter Annual' where id=2");
            Sql("update membershiptypes set name=' Annually' where id=3");


        }

        public override void Down()
        {
        }
    }
}
