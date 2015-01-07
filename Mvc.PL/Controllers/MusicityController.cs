using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using Mvc.PL.Mappers;

namespace Mvc.PL.Controllers
{
    public class MusicityController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly ITopicService topicService;

        public MusicityController(ICategoryService categoryService, ITopicService topicService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.topicService = topicService;
            this.postService = postService;
        }

        public ViewResult Categories()
        {
            return
                View(categoryService.GetAllCategories().Select(CategoriesPageMapper.ToCategoriesPageCategoryViewModel));
        }

        public ActionResult Posts(string topic)
        {
            var topicEntity = topicService.GetAllTopics().Single(t => string.Equals(t.Name, topic, StringComparison.CurrentCultureIgnoreCase));
            var postEntities = postService.GetAllPosts()
                .Where(post => string.Equals(post.Topic.Name, topic, StringComparison.CurrentCultureIgnoreCase));
            return View(TopicPageMapper.ToTopicPageTopicViewModel(topicEntity, postEntities));
        }
    }
}