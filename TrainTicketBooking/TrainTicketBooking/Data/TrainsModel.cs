using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class TrainsModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Train Name")]
        public string TrainName { get; set; }
        [Required]
        [Display(Name ="Train Type")]
        public string TrainType { get; set; }
        [Required]
        [Display(Name = "Site")]
        public string Site { get; set; }
        [Required]
        [Display(Name = "Start Station")]
        public int StartStation { get; set; }
        [Required]
        [Display(Name = "End Station")]
        public int EndStation { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        
        public int RouteId { get; set; }

        public ICollection<ScheduleModel> Schedules { get; set; }
        public ICollection<TicketModel> Tickets { get; set; }
        [ForeignKey("RouteId")]
        public  RoutesModel Routes { get; set; }
        [ForeignKey("StartStation")]
        public StationModel Stations1 { get; set; }
        [ForeignKey("EndStation")]
        public StationModel Stations2 { get; set; }

    }
}