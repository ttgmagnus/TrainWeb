using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Models
{
    public class OrderTicketVM
    {
        [Required]
        [Display(Name = "Train Name")]
        public int TrainId { get; set; }
        [Required]
        [Display(Name="Order Date")]
        public string OrderDate { get; set; }
        [Required]
        [Display(Name ="Station From")]
        public string StationFrom { get; set; }
        [Required]
        [Display(Name = "Station To")]
        public string StationTo { get; set; }
        [Required]
        [Display(Name = "Travel Date")]
        public string TravelDate { get; set; }
    }
}