using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Categories = new HashSet<Category>();
            Topics = new HashSet<Topic>();
            Posts = new HashSet<Post>();
            Replies = new HashSet<Reply>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastActivity { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}