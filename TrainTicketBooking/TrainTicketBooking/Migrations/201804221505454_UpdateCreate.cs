namespace TrainTicketBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedDate = c.String(nullable: false),
                        ValidFrom = c.String(nullable: false),
                        ValidTo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarriageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketModels", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        TrainType = c.String(),
                        OrderDate = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StationFrom = c.String(nullable: false),
                        StationTo = c.String(nullable: false),
                        TravelDate = c.String(nullable: false),
                        CustomerID = c.String(),
                        Issuedby = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainsModels", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.TrainId);
            
            CreateTable(
                "dbo.TrainsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainName = c.String(nullable: false),
                        TrainType = c.String(nullable: false),
                        Site = c.String(nullable: false),
                        StartStation = c.Int(nullable: false),
                        EndStation = c.Int(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        RouteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoutesModels", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.StationModels", t => t.StartStation, cascadeDelete: false)
                .ForeignKey("dbo.StationModels", t => t.EndStation, cascadeDelete: false)
                .Index(t => t.StartStation)
                .Index(t => t.EndStation)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.RoutesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteName = c.String(nullable: false),
                        RouteDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        StationId = c.Int(nullable: false),
                        ArrivalTime = c.String(nullable: false),
                        DepartureTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StationModels", t => t.StationId, cascadeDelete: true)
                .ForeignKey("dbo.TrainsModels", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.TrainId)
                .Index(t => t.StationId);
            
            CreateTable(
                "dbo.StationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StationName = c.String(nullable: false),
                        StationCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        JoinDate = c.String(nullable: false),
                        BirthDate = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(maxLength: 25));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarriageModels", "TicketId", "dbo.TicketModels");
            DropForeignKey("dbo.TicketModels", "TrainId", "dbo.TrainsModels");
            DropForeignKey("dbo.TrainsModels", "EndStation", "dbo.StationModels");
            DropForeignKey("dbo.TrainsModels", "StartStation", "dbo.StationModels");
            DropForeignKey("dbo.ScheduleModels", "TrainId", "dbo.TrainsModels");
            DropForeignKey("dbo.ScheduleModels", "StationId", "dbo.StationModels");
            DropForeignKey("dbo.TrainsModels", "RouteId", "dbo.RoutesModels");
            DropIndex("dbo.ScheduleModels", new[] { "StationId" });
            DropIndex("dbo.ScheduleModels", new[] { "TrainId" });
            DropIndex("dbo.TrainsModels", new[] { "RouteId" });
            DropIndex("dbo.TrainsModels", new[] { "EndStation" });
            DropIndex("dbo.TrainsModels", new[] { "StartStation" });
            DropIndex("dbo.TicketModels", new[] { "TrainId" });
            DropIndex("dbo.CarriageModels", new[] { "TicketId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.StaffModels");
            DropTable("dbo.StationModels");
            DropTable("dbo.ScheduleModels");
            DropTable("dbo.RoutesModels");
            DropTable("dbo.TrainsModels");
            DropTable("dbo.TicketModels");
            DropTable("dbo.CarriageModels");
            DropTable("dbo.AnnouncementModels");
        }
    }
}
