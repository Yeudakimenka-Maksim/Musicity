using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.CreatePostPage
{
    public class CreatePostPagePostViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}