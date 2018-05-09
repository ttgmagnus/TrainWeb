using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class AnnouncementModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "CreatedDate")]
        public string CreatedDate { get; set; }
        [Required]
        [Display(Name = "Valid From")]
        public string ValidFrom { get; set; }
        [Required]
        [Display(Name = "Valid To")]
        public string ValidTo { get; set; }

    }
}