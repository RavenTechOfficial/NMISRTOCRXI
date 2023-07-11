using System.ComponentModel.DataAnnotations;
using thesis.Models;

namespace thesis.Core.ViewModel
{
    public class RegisterRoleViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required")]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "middleName")]
        public string middleName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "contactNo")]
        public string contactNo { get; set; }

        [Display(Name = "Image")]
        public string image { get; set; }

        [Display(Name = "Roles")]
        public MeatEstablishment MeatEstablishment { get; set; }
    }
}
