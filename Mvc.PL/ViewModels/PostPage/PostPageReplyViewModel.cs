using System;

namespace Mvc.PL.ViewModels.PostPage
{
    public class PostPageReplyViewModel
    {
        public DateTime WrittenTime { get; set; }
        public string Content { get; set; }
        public PostPageUserViewModel Writer { get; set; }
    }
}