﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TrainTicketBooking.Data;

namespace TrainTicketBooking.Entities
{
    public class RoutesConfiguration: EntityTypeConfiguration<RoutesModel>
    {
        public RoutesConfiguration()
        {

        }
    }
}