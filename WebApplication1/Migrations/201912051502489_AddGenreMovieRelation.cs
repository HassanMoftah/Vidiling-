namespace Vidiling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreMovieRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreiD", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreiD");
            AddForeignKey("dbo.Movies", "GenreiD", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropForeignKey("dbo.Movies", "GenreiD", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreiD" });
            DropColumn("dbo.Movies", "GenreiD");
        }
    }
}
