using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class RoutesModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Route Name")]
        public string RouteName { get; set; }
        [Display(Name = "Route Description")]
        public string RouteDescription { get; set; }

        public ICollection<TrainsModel> Trains { get; set; }
    }
}