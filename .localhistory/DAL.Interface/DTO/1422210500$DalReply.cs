using System;

namespace DAL.Interface.DTO
{
    public class DalReply : IEntity
    {
        public DateTime WrittenTime { get; set; }
        public bool IsSubject { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int WriterId { get; set; }
        public DalPost Post { get; set; }
        public DalUser Writer { get; set; }
        public int Id { get; set; }
    }
}