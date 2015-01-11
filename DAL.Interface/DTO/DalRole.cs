using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalRole : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DalUser> Users { get; set; }
        public int Id { get; set; }
    }
}