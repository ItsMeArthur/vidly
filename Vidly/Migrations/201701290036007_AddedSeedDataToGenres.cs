namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeedDataToGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Description) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Description) VALUES ('Action')");
            Sql("INSERT INTO Genres (Description) VALUES ('Science Fiction')");
            Sql("INSERT INTO Genres (Description) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Description) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Description) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Description) VALUES ('Romantic Comedy')");
            Sql("INSERT INTO Genres (Description) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (Description) VALUES ('Advendture')");
            Sql("INSERT INTO Genres (Description) VALUES ('Noir')");

        }
        
        public override void Down()
        {
        }
    }
}
