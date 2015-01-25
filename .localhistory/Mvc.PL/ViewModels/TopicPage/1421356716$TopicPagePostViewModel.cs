using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc.PL.ViewModels.TopicPage
{
    public class TopicPagePostViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public TopicPageUserViewModel Creator { get; set; }
        public int ReplyCount { get; set; }
    }
}