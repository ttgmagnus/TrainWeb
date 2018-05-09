using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Models
{
    public class ApplicationRoleVM
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Role Name Required")]
        [StringLength(256, ErrorMessage = "The role must be 256 characters or shorter")]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}