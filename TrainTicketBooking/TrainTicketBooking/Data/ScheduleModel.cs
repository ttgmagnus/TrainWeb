using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains the properties for the ScheduleModel.
    /// </summary>
    public class ScheduleModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for TrainId.
        [Required]
        [Display(Name ="Train Name")]
        public int TrainId { get; set; }

        // auto-implementet property for StationId.
        [Required]
        [Display(Name = "Station Name")]
        public int StationId { get; set; }

        // auto-implementet property for ArrivalTime.
        [Required]
        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }

        // auto-implementet property for DepartureTime.
        [Required]
        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; }

        // auto-implementet property for Trains using the foreign Key TrainId.
        [ForeignKey("TrainId")]
        public TrainsModel Trains { get; set; }

        // auto-implementet property for Stations using the foreign key StationId.
        [ForeignKey("StationId")]
        public StationModel Stations { get; set; }
    }
}