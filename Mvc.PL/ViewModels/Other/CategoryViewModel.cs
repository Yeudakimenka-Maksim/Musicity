using System.Collections.Generic;

namespace Mvc.PL.ViewModels.Other
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public UserViewModel Creator { get; set; }
        public ICollection<TopicViewModel> Topics { get; set; }
    }
}