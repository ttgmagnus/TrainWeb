using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainTicketBooking.Areas.Admin.Models
{
    /// <summary>
    /// The requirements for the possibility to create a new admin user.
    /// </summary>
    public class CreateUserVM
    {
        [Required]
        [Display(Name = "First Name")]
        // getter and setter for the Firstname
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        // getter and setter for the Lastname
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        // getter and setter for the Email
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        // getter and setter for the Gender
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        // getter and setter for the BirthDate
        public string BirthDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        // getter and setter for the Password
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        // getter and setter for password confirmation.
        public string ConfirmPassword { get; set; }
    }
}