namespace TrainTicketBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TicketModels", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.TicketModels", "TrainType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketModels", "TrainType", c => c.String());
            AlterColumn("dbo.TicketModels", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
