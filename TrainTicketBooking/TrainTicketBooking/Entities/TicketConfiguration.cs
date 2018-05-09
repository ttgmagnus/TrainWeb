using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Entities
{
    public class TicketConfiguration: EntityTypeConfiguration<TicketModel>
    {
        public TicketConfiguration()
        {
           this.HasRequired<TrainsModel>(s => s.Trains)
          .WithMany(g => g.Tickets)
          .HasForeignKey<int>(s => s.TrainId);

            Property(u => u.Price).IsOptional();
            Property(u => u.Issuedby).IsOptional();
        }
    }
}