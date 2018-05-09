using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Entities
{
    public class CarriageConfiguration: EntityTypeConfiguration<CarriageModel>
    {
        public CarriageConfiguration()
        {
            this.HasRequired<TicketModel>(s => s.Tickets)
         .WithMany(g => g.Carriages)
         .HasForeignKey<int>(s => s.TicketId);
        }
    }
}