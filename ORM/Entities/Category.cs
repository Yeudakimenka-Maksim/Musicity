using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}