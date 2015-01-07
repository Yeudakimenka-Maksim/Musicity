using System;
using System.Collections.Generic;

namespace Mvc.PL.ViewModels.Other
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastActivity { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
        public ICollection<TopicViewModel> Topics { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        public ICollection<ReplyViewModel> Replies { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}