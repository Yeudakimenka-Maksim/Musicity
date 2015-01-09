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
            return View(categoryService.GetAllCategories()
                .Select(CategoriesPageMapper.ToCategoriesPageCategoryViewModel));
        }

        public ViewResult Posts(string topic)
        {
            return View(topicService.GetTopicByName(topic).ToTopicPageTopicViewModel());
        }

        public ActionResult Replies(string post)
        {
            return View(postService.GetPostByName(post).ToPostPagePostViewModel());
        }
    }
}