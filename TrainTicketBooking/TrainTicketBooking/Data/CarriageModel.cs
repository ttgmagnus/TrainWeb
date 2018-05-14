using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains properties for CarriageModel.
    /// </summary>
    public class CarriageModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for TicketId.
        [Required]
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }

        // auto-implementet property for Name.
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // auto-implementet property for Type.
        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }

        // auto-implementet property for Weight.
        [Required]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        // auto-implementet property for Height.
        [Required]
        [Display(Name = "Height")]
        public decimal Height { get; set; }

        // auto-implementet property for Width.
        [Required]
        [Display(Name = "Width")]
        public decimal Width { get; set; }

        // auto-implementet property for Lenght.
        [Required]
        [Display(Name = "Length")]
        public decimal Length { get; set; }

        // auto-implementet property for Description.
        [Display(Name = "Description")]
        public string Description { get; set; }

        // auto-implementet property for TicketModel named Tickets using foreign key TicketId.
        [ForeignKey("TicketId")]
        public TicketModel Tickets { get; set; }

    }
}