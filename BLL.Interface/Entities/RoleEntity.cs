using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}