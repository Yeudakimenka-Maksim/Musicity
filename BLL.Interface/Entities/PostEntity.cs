using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? TopicId { get; set; }
        public UserEntity Creator { get; set; }
        public TopicEntity Topic { get; set; }
        public ICollection<ReplyEntity> Replies { get; set; }
    }
}