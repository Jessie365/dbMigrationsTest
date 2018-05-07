namespace Photography.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        PrimaryCamera_Id = c.Int(nullable: false),
                        SecondaryCamera_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.PrimaryCamera_Id)
                .ForeignKey("dbo.Cameras", t => t.SecondaryCamera_Id)
                .Index(t => t.PrimaryCamera_Id)
                .Index(t => t.SecondaryCamera_Id);
            
            CreateTable(
                "dbo.Lenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        FocalLength = c.Int(),
                        MaxAperture = c.Decimal(precision: 18, scale: 1),
                        CompatibleWith = c.String(),
                        Photographer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .Index(t => t.Photographer_Id);
            
            CreateTable(
                "dbo.Workshops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Location = c.String(nullable: false),
                        PricePerParticipant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Trainer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Trainer_Id)
                .Index(t => t.Trainer_Id);
            
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        IsFullFrame = c.Boolean(),
                        MinISO = c.Int(nullable: false),
                        MaxISO = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotographersWorkshops",
                c => new
                    {
                        PhotographerId = c.Int(nullable: false),
                        WorkshopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhotographerId, t.WorkshopId })
                .ForeignKey("dbo.Photographers", t => t.PhotographerId, cascadeDelete: true)
                .ForeignKey("dbo.Workshops", t => t.WorkshopId, cascadeDelete: true)
                .Index(t => t.PhotographerId)
                .Index(t => t.WorkshopId);
            
            CreateTable(
                "dbo.DSLRCameras",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaxShutterSpeed = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MirrorlessCameras",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaxVideoResolution = c.String(),
                        MaxFrameRate = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MirrorlessCameras", "Id", "dbo.Cameras");
            DropForeignKey("dbo.DSLRCameras", "Id", "dbo.Cameras");
            DropForeignKey("dbo.Photographers", "SecondaryCamera_Id", "dbo.Cameras");
            DropForeignKey("dbo.Photographers", "PrimaryCamera_Id", "dbo.Cameras");
            DropForeignKey("dbo.PhotographersWorkshops", "WorkshopId", "dbo.Workshops");
            DropForeignKey("dbo.PhotographersWorkshops", "PhotographerId", "dbo.Photographers");
            DropForeignKey("dbo.Workshops", "Trainer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Lenses", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Accessories", "Owner_Id", "dbo.Photographers");
            DropIndex("dbo.MirrorlessCameras", new[] { "Id" });
            DropIndex("dbo.DSLRCameras", new[] { "Id" });
            DropIndex("dbo.PhotographersWorkshops", new[] { "WorkshopId" });
            DropIndex("dbo.PhotographersWorkshops", new[] { "PhotographerId" });
            DropIndex("dbo.Workshops", new[] { "Trainer_Id" });
            DropIndex("dbo.Lenses", new[] { "Photographer_Id" });
            DropIndex("dbo.Photographers", new[] { "SecondaryCamera_Id" });
            DropIndex("dbo.Photographers", new[] { "PrimaryCamera_Id" });
            DropIndex("dbo.Accessories", new[] { "Owner_Id" });
            DropTable("dbo.MirrorlessCameras");
            DropTable("dbo.DSLRCameras");
            DropTable("dbo.PhotographersWorkshops");
            DropTable("dbo.Cameras");
            DropTable("dbo.Workshops");
            DropTable("dbo.Lenses");
            DropTable("dbo.Photographers");
            DropTable("dbo.Accessories");
        }
    }
}
