using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public DalUser Creator { get; set; }
        public ICollection<DalTopic> Topics { get; set; }
    }
}