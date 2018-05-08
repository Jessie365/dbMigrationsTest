namespace Photography.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCamBattery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "BatteryType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cameras", "BatteryType");
        }
    }
}
