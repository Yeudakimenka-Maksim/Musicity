using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.AdminPages
{
    public class AdminPagesCategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Creation Time")]
        public DateTime CreationTime { get; set; }

        public int CreatorId { get; set; }

        [DisplayName("Created by")]
        public AdminPagesUserViewModel Creator { get; set; }
    }
}