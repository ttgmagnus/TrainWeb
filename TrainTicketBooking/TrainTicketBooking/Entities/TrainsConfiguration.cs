using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Entities
{
    /// <summary>
    /// The configuration for train entities derived from corresponding models. 
    /// </summary>
    public class TrainsConfiguration: EntityTypeConfiguration<TrainsModel>
    {
        public TrainsConfiguration()
        {

            this.HasRequired<RoutesModel>(s => s.Routes)
            .WithMany(g => g.Trains)
            .HasForeignKey<int>(s => s.RouteId);
            this.HasRequired<StationModel>(s => s.Stations1)
            .WithMany(g => g.Trains1)
            .HasForeignKey<int>(s => s.StartStation);
            this.HasRequired<StationModel>(s => s.Stations2)
            .WithMany(g => g.Trains2)
            .HasForeignKey<int>(s => s.EndStation);
        }
    }
}