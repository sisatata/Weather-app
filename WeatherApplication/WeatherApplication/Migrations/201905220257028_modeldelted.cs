namespace WeatherApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeldelted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CountryPopulations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CountryPopulations",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
        }
    }
}
