using System.Collections.Generic;

namespace Mvc.PL.ViewModels.TopicPage
{
    public class TopicPageTopicViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCount { get; set; }
        public IEnumerable<TopicPagePostViewModel> Posts { get; set; }
    }
}
