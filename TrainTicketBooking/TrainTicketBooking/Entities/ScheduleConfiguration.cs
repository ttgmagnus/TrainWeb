using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Entities
{
    public class ScheduleConfiguration: EntityTypeConfiguration<ScheduleModel>
    {
        public ScheduleConfiguration()
        {
            this.HasRequired<TrainsModel>(s => s.Trains)
           .WithMany(g => g.Schedules)
           .HasForeignKey<int>(s => s.TrainId);

            this.HasRequired<StationModel>(s => s.Stations)
           .WithMany(g => g.Schedules)
           .HasForeignKey<int>(s => s.StationId);
        }
    }
}