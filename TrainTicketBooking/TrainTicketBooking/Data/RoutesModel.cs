using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains properties for the RoutesModel.
    /// </summary>
    public class RoutesModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for RouteName.
        [Required]
        [Display(Name ="Route Name")]
        public string RouteName { get; set; }

        // auto-implementet property for RouteDescription.
        [Display(Name = "Route Description")]
        public string RouteDescription { get; set; }

        // auto-implementet property for the collection named Trains.
        public ICollection<TrainsModel> Trains { get; set; }
    }
}