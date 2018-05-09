using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Data
{
    public class StaffModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Join Date")]
        public string JoinDate { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public string BirthDate { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }
    }
}