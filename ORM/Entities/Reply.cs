using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Reply")]
    public class Reply
    {
        public int Id { get; set; }
        public DateTime WrittenTime { get; set; }
        public bool IsSubject { get; set; }

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }
        public int WriterId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User Writer { get; set; }
    }
}