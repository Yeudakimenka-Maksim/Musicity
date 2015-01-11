using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.RegisterPage
{
    public class RegisterPageRegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Captcha")]
        [Required]
        public string Captcha { get; set; }
    }
}