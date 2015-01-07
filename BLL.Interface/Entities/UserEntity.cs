using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastActivity { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<CategoryEntity> Categories { get; set; }
        public ICollection<TopicEntity> Topics { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
        public ICollection<ReplyEntity> Replies { get; set; }
        public ICollection<RoleEntity> Roles { get; set; }
    }
}