namespace WeatherApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReligiontoLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherDetails", "LocationName", c => c.String(nullable: false));
            DropColumn("dbo.WeatherDetails", "ReligionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeatherDetails", "ReligionName", c => c.String(nullable: false));
            DropColumn("dbo.WeatherDetails", "LocationName");
        }
       
    }
}
