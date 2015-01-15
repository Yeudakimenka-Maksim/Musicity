using System;
using System.ComponentModel;

namespace Mvc.PL.ViewModels.AdminPages
{
    public class AdminPagesReplyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Written Time")]
        public DateTime WrittenTime { get; set; }

        public bool IsSubject { get; set; }

        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("Belongs to Post")]
        public AdminPagesPostViewModel Post { get; set; }

        [DisplayName("Written by")]
        public AdminPagesUserViewModel Writer { get; set; }
    }
}