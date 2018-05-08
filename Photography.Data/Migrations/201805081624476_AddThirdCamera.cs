namespace Photography.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThirdCamera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photographers", "ThirdCamera_Id", c => c.Int());
            CreateIndex("dbo.Photographers", "ThirdCamera_Id");
            AddForeignKey("dbo.Photographers", "ThirdCamera_Id", "dbo.Cameras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photographers", "ThirdCamera_Id", "dbo.Cameras");
            DropIndex("dbo.Photographers", new[] { "ThirdCamera_Id" });
            DropColumn("dbo.Photographers", "ThirdCamera_Id");
        }
    }
}
