using System.Collections.Generic;

namespace Mvc.PL.ViewModels.Other
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public UserViewModel Creator { get; set; }
        public CategoryViewModel Category { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
    }
}