using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalTopic : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public DalUser Creator { get; set; }
        public DalCategory Category { get; set; }
        public ICollection<DalPost> Posts { get; set; }
        public int Id { get; set; }
    }
}