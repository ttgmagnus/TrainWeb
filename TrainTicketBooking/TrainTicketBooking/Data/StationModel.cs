using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class StationModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Station Name")]
        public string StationName { get; set; }
        [Required]
        [Display(Name ="Station Code")]
        public string StationCode {get; set;}

        public ICollection<ScheduleModel> Schedules { get; set; }
        public ICollection<TrainsModel> Trains1 { get; set; }
        public ICollection<TrainsModel> Trains2 { get; set; }
    }
}