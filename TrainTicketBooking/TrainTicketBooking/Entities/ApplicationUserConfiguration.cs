using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Models;

namespace TrainTicketBooking.Entities
{
    /// <summary>
    /// The configuration for train entities derived from corresponding models. 
    /// </summary>
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