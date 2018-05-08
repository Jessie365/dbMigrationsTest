namespace Photography.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCamPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cameras", "Price");
        }
    }
}
