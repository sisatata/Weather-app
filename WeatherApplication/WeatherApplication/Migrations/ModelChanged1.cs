namespace WeatherApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeatherDetails", "RealDateTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeatherDetails", "RealDateTime", c => c.DateTime(nullable: false));
        }
    }
}
