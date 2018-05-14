using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    /// <summary>
    /// Contains properties for the StaffModel.
    /// </summary>
    public class StaffModel
    {
        // auto-implementet property for Id.
        [Key]
        public int Id { get; set; }

        // auto-implementet property for FirstName.
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        // auto-implementet property for LastName.
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        // auto-implementet property for Email with datatype EmailAddress.
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // auto-implementet property for Address.
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        // auto-implementet property for JoinDate.
        [Required]
        [Display(Name = "Join Date")]
        public string JoinDate { get; set; }

        // auto-implementet property for BirthDate.
        [Required]
        [Display(Name = "Date of Birth")]
        public string BirthDate { get; set; }

        // auto-implementet property for Description.
        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }
    }
}