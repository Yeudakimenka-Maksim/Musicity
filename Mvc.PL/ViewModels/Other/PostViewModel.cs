using System.Collections.Generic;

namespace Mvc.PL.ViewModels.Other
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int? TopicId { get; set; }
        public UserViewModel Creator { get; set; }
        public TopicViewModel Topic { get; set; }
        public ICollection<ReplyViewModel> Replies { get; set; }
    }
}