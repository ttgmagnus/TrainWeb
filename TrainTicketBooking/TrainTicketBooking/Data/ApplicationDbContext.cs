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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
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
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ApplicationRole> IdentityRoles { get; set; }
        public DbSet<StationModel> StationModels { get; set; }
        public DbSet<AnnouncementModel> AnnouncementModels { get; set; }
        public DbSet<TrainsModel> TrainsModels { get; set; }
        public DbSet<RoutesModel> RoutesModels { get; set; }
        public DbSet<ScheduleModel> ScheduleModels { get; set; }
        public DbSet<TicketModel> TicketModels { get; set; }
        public DbSet<StaffModel> StaffModels { get; set; }
        public DbSet<CarriageModel> CarriageModels { get; set; }

       
    }
}