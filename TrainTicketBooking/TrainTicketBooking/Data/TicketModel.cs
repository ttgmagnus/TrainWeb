using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class TicketModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Train Name")]
        public int TrainId { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Station From")]
        public string StationFrom { get; set; }
        [Required]
        [Display(Name = "Station To")]
        public string StationTo { get; set; }
        [Required]
        [Display(Name = "Travel Date")]
        public string TravelDate { get; set; }
        public string CustomerID { get; set; }

        public string Issuedby { get; set; }

        [ForeignKey("TrainId")]
        public TrainsModel Trains { get; set; }

        public ICollection<CarriageModel> Carriages { get; set; }

    }
}