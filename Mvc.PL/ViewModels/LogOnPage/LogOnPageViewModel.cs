using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.LogOnPage
{
    public class LogOnPageViewModel
    {
        [Display(Name = "Username")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}