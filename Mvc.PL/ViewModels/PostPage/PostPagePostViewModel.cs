using System.Collections.Generic;

namespace Mvc.PL.ViewModels.PostPage
{
    public class PostPagePostViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PostPageReplyViewModel> Replies { get; set; }
    }
}