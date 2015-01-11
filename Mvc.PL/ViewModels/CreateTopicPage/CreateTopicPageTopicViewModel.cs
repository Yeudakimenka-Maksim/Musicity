using System.ComponentModel.DataAnnotations;

namespace Mvc.PL.ViewModels.CreateTopicPage
{
    public class CreateTopicPageTopicViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}