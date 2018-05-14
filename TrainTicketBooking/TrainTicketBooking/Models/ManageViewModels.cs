using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace TrainTicketBooking.Models
{
    /// <summary>
    /// Class sets and gets the values by the index view.
    /// </summary>
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    /// <summary>
    /// Class that manages logins for a user. ie google, facebook others.
    /// </summary>
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    /// <summary>
    /// setter and getter of purpose
    /// </summary>
    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    /// <summary>
    /// This class sets a new password for an account.
    /// 
    /// It determine if the password upholds the minimum requirements.
    /// Double checks the password with a match.
    /// And getter and setter for NewPassword and ConfirmPassword
    /// </summary>
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// This is the class for making a new password for an account.
    /// 
    /// Checks if the user have the old password.
    /// Determine if the new password upholds the minimum requirements.
    /// Double checks the password with a match.
    /// And getter and setter for NewPassword and ConfirmPassword
    /// </summary>
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Add a phone number to the user.
    /// Getter and setter for the number.
    /// </summary>
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    /// <summary>
    /// Verifies the phonenumber.
    /// </summary>
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
    
    /// <summary>
    /// Setter and getter for the selected provider and setter and getter for the collection providers.
    /// </summary>
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}