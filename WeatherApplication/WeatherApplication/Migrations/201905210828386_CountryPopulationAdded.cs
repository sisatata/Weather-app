namespace WeatherApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryPopulationAdded : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.CountryPopulations");
        }
    }
}
