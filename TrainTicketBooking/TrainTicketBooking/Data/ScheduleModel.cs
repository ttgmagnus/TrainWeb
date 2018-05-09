using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class ScheduleModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Train Name")]
        public int TrainId { get; set; }
        [Required]
        [Display(Name = "Station Name")]
        public int StationId { get; set; }
        [Required]
        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }
        [Required]
        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; }

        [ForeignKey("TrainId")]
        public TrainsModel Trains { get; set; }

        [ForeignKey("StationId")]
        public StationModel Stations { get; set; }
    }
}