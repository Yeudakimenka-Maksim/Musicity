using System;

namespace BLL.Interface.Entities
{
    public class ReplyEntity
    {
        public int Id { get; set; }
        public DateTime WrittenTime { get; set; }
        public bool IsSubject { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int WriterId { get; set; }
        public PostEntity Post { get; set; }
        public UserEntity Writer { get; set; }
    }
}