using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class TopicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public UserEntity Creator { get; set; }
        public CategoryEntity Category { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}