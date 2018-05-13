using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains the properties for the TrainsModel.
    /// </summary>
    public class TrainsModel
    {
        // auto-implemented property for ID.
        [Key]
        public int Id { get; set; }
        
        // auto-implementet property for TrainName.
        [Required]
        [Display(Name = "Train Name")]
        public string TrainName { get; set; }

        // auto-implementet property for TrainType.
        [Required]
        [Display(Name ="Train Type")]
        public string TrainType { get; set; }

        // auto-implementet property for Site.
        [Required]
        [Display(Name = "Site")]
        public string Site { get; set; }

        // auto-implementet property for StartStation.
        [Required]
        [Display(Name = "Start Station")]
        public int StartStation { get; set; }

        // auto-implementet property for EndStation.
        [Required]
        [Display(Name = "End Station")]
        public int EndStation { get; set; }

        // auto-implementet property for StartTime.
        [Required]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        // auto-implementet property for EndTime.
        [Required]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        // auto-implementet property for RouteId.
        public int RouteId { get; set; }

        // auto-implementet property for the collection Schedules.
        public ICollection<ScheduleModel> Schedules { get; set; }

        // auto-implementet property for the collection Tickets.
        public ICollection<TicketModel> Tickets { get; set; }

        // auto-implementet property for the RoutesModel named routes using RouteId as foreign key.
        [ForeignKey("RouteId")]
        public  RoutesModel Routes { get; set; }

        // auto-implementet property for StationModel named Stations1 using StartStation as foreign key.
        [ForeignKey("StartStation")]
        public StationModel Stations1 { get; set; }

        // auto-implementet property for for StationModel named Stations2 using EndStation as foreign key.
        [ForeignKey("EndStation")]
        public StationModel Stations2 { get; set; }

    }
}