namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editinginMovie : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "GenreiD" });
            CreateIndex("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenreId" });
            CreateIndex("dbo.Movies", "GenreiD");
        }
    }
}
