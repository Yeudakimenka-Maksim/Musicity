using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalPost : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? TopicId { get; set; }
        public DalUser Creator { get; set; }
        public DalTopic Topic { get; set; }
        public ICollection<DalReply> Replies { get; set; }
    }
}