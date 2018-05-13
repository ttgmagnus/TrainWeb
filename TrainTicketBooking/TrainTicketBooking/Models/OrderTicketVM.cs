using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Models
{
    /// <summary>
    /// Class contains methods for getting and setting all values pertaining to tickets.
    /// </summary>
    public class OrderTicketVM
    {
        // get/set trainId
        [Required]
        [Display(Name = "Train Name")]
        public int TrainId { get; set; }
        
        // get/set OrderDate
        [Required]
        [Display(Name="Order Date")]
        public string OrderDate { get; set; }

        // get/set StationFrom
        [Required]
        [Display(Name ="Station From")]
        public string StationFrom { get; set; }

        //get/set StationTo
        [Required]
        [Display(Name = "Station To")]
        public string StationTo { get; set; }

        // get/set TravelDate
        [Required]
        [Display(Name = "Travel Date")]
        public string TravelDate { get; set; }
    }
}