using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.AdminPages
{
    public class AdminPagesTopicViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Creation Time")]
        public DateTime CreationTime { get; set; }

        [DisplayName("Created by")]
        public AdminPagesUserViewModel Creator { get; set; }

        [DisplayName("Belongs to Category")]
        public AdminPagesCategoryViewModel Category { get; set; }
    }
}