namespace WeatherApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherDetails", "Pressure", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherDetails", "Pressure");
        }
    }
}
