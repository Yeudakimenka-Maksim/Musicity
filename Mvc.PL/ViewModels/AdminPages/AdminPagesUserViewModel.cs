using System;
using System.ComponentModel;

namespace Mvc.PL.ViewModels.AdminPages
{
    public class AdminPagesUserViewModel
    {
        public int Id { get; set; }

        [DisplayName("Username")]
        public string Name { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Join date")]
        public DateTime JoinDate { get; set; }

        [DisplayName("Last Activity")]
        public DateTime LastActivity { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("Online?")]
        public bool IsOnline { get; set; }
    }
}