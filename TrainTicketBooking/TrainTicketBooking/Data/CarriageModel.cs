using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class CarriageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "Height")]
        public decimal Height { get; set; }
        [Required]
        [Display(Name = "Width")]
        public decimal Width { get; set; }
        [Required]
        [Display(Name = "Length")]
        public decimal Length { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("TicketId")]
        public TicketModel Tickets { get; set; }

    }
}