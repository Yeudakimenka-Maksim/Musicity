using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public UserEntity Creator { get; set; }
        public ICollection<TopicEntity> Topics { get; set; }
    }
}