using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Entities
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.FirstName).HasMaxLength(100).IsOptional();
            Property(u => u.LastName).HasMaxLength(100).IsOptional();
            Property(u => u.Gender).HasMaxLength(25).IsOptional();
            Property(u => u.Address).HasMaxLength(250).IsOptional();
            Property(u => u.BirthDate).HasMaxLength(100).IsOptional();

        }
    }
}