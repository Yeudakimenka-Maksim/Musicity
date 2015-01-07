using System;

namespace Mvc.PL.ViewModels.Other
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public DateTime WrittenTime { get; set; }
        public bool IsSubject { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int WriterId { get; set; }
        public PostViewModel Post { get; set; }
        public UserViewModel Writer { get; set; }
    }
}