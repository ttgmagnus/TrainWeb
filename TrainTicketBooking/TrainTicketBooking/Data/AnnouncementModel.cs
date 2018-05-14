using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains the properties for the AnnouncementModel
    /// </summary>
    public class AnnouncementModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for Title.
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }

        // auto-implementet property for Description.
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        // auto-implementet property for CreateDate.
        [Required]
        [Display(Name = "CreatedDate")]
        public string CreatedDate { get; set; }

        // auto-implementet property for ValidFrom.
        [Required]
        [Display(Name = "Valid From")]
        public string ValidFrom { get; set; }

        // auto-implementet property for ValidTo.
        [Required]
        [Display(Name = "Valid To")]
        public string ValidTo { get; set; }

    }
}