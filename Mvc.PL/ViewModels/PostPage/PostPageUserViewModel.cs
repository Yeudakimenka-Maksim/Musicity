using System;
using System.Collections.Generic;

namespace Mvc.PL.ViewModels.PostPage
{
    public class PostPageUserViewModel
    {
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public IEnumerable<PostPagePostViewModel> Posts { get; set; }
        public IEnumerable<PostPageRoleViewModel> Roles { get; set; }
    }
}