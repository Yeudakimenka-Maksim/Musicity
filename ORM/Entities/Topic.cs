using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Topic")]
    public class Topic
    {
        public Topic()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public virtual User Creator { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}