using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastActivity { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<DalCategory> Categories { get; set; }
        public ICollection<DalTopic> Topics { get; set; }
        public ICollection<DalPost> Posts { get; set; }
        public ICollection<DalReply> Replies { get; set; }
        public ICollection<DalRole> Roles { get; set; }
        public int Id { get; set; }
    }
}