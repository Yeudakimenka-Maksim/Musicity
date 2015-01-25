using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.AdminPages
{
    public class AdminPagesPostViewModel
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
        public int TopicId { get; set; }

        [DisplayName("Created by")]
        public AdminPagesUserViewModel Creator { get; set; }

        [DisplayName("Belongs to Topic")]
        public AdminPagesTopicViewModel Topic { get; set; }
    }
}