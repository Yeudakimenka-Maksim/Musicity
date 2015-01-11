using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.CreateReplyPage
{
    public class CreateReplyPageReplyViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}