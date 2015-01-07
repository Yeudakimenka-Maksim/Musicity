using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? TopicId { get; set; }
        public virtual User Creator { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}