using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainTicketBooking.Entities;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Defines what the ApplicationDbContext contains.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Sets the configuration of the context.
        /// </summary>
        /// <param name="modelBuilder">Model to be used for mapping the database schema.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnnouncementConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new CarriageConfiguration());
            modelBuilder.Configurations.Add(new RoutesConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new StaffConfiguration());
            modelBuilder.Configurations.Add(new StationConfiguration());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new TrainsConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Create a new ApplicationDbContext.
        /// </summary>
        /// <returns>The made ApplicationDbContext</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // auto-implementet property for the DbSet named IdentityRoles defined by ApplicationRole.
        public DbSet<ApplicationRole> IdentityRoles { get; set; }

        // auto-implementet property for the DbSet named StationModels defined by StationModel.
        public DbSet<StationModel> StationModels { get; set; }

        // auto-implementet property for the DbSet named AnnouncementModels defined by AnnouncementModel.
        public DbSet<AnnouncementModel> AnnouncementModels { get; set; }

        // auto-implementet property for the DbSet named TrainsModels defined by TrainsModel.
        public DbSet<TrainsModel> TrainsModels { get; set; }

        // auto-implementet property for the DbSet named RoutesModels defined by RoutesModel.
        public DbSet<RoutesModel> RoutesModels { get; set; }

        // auto-implementet property for the DbSet named ScheduleModels defined by ScheduleModel.
        public DbSet<ScheduleModel> ScheduleModels { get; set; }

        // auto-implementet property for the DbSet named TicketModels defined by TicketModel.
        public DbSet<TicketModel> TicketModels { get; set; }

        // auto-implementet property for the DbSet named StaffModels defined by StaffModel.
        public DbSet<StaffModel> StaffModels { get; set; }

        // auto-implementet property for the DbSet named CarriageModels defined by CarriageModel.
        public DbSet<CarriageModel> CarriageModels { get; set; }

       
    }
}