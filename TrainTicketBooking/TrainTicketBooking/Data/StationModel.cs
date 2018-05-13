using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains properties for StationModel.
    /// </summary>
    public class StationModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for StationName.
        [Required]
        [Display(Name = "Station Name")]
        public string StationName { get; set; }

        // auto-implementet property for StationCode.
        [Required]
        [Display(Name ="Station Code")]
        public string StationCode {get; set;}

        // auto-implementet property for the collection Schedules.
        public ICollection<ScheduleModel> Schedules { get; set; }

        // auto-implementet property for the collection Trains1.
        public ICollection<TrainsModel> Trains1 { get; set; }

        // auto-implementet property for the collection Trains2.
        public ICollection<TrainsModel> Trains2 { get; set; }
    }
}