using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains the properties for the TicketModel.
    /// </summary>
    public class TicketModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for TrainId.
        [Required]
        [Display(Name = "Train Name")]
        public int TrainId { get; set; }

        // auto-implementet property for OrderDate.
        [Required]
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }

        // auto-implementet property for Price
        public decimal Price { get; set; }

        // auto-implementet property for StationFrom.
        [Required]
        [Display(Name = "Station From")]
        public string StationFrom { get; set; }

        // auto-implementet property for StationTo.
        [Required]
        [Display(Name = "Station To")]
        public string StationTo { get; set; }

        // auto-implementet property for TravelDate.
        [Required]
        [Display(Name = "Travel Date")]
        public string TravelDate { get; set; }

        // auto-implementet property for CustomerID.
        public string CustomerID { get; set; }

        // auto-implementet property for Issuedby.
        public string Issuedby { get; set; }

        // auto-implementet property for TrainsModel named Trains using TrainId as foreign Key.
        [ForeignKey("TrainId")]
        public TrainsModel Trains { get; set; }

        // auto-implementet property for the collection Carriages.
        public ICollection<CarriageModel> Carriages { get; set; }

    }
}