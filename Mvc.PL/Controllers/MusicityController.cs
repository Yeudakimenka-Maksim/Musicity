using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Mvc.PL.Mappers.UserPages;
using Mvc.PL.ViewModels.CreatePostPage;
using Mvc.PL.ViewModels.CreateReplyPage;
using Mvc.PL.ViewModels.CreateTopicPage;

namespace Mvc.PL.Controllers
{
    public class MusicityController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly IReplyService replyService;
        private readonly ITopicService topicService;
        private readonly IUserService userService;

        public MusicityController(ICategoryService categoryService, IPostService postService, IReplyService replyService,
            ITopicService topicService, IUserService userService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.replyService = replyService;
            this.topicService = topicService;
            this.userService = userService;
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

        public ViewResult Replies(string post)
        {
            return View(postService.GetPostByName(post).ToPostPagePostViewModel());
        }

        public ViewResult CreateReply(string post)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReply(string post, CreateReplyPageReplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                replyService.CreateReply(new ReplyEntity
                {
                    WrittenTime = DateTime.Now,
                    Content = model.Content,
                    PostId = postService.GetPostByName(post).Id,
                    WriterId = userService.GetUserByName(User.Identity.Name).Id
                });
            }
            return RedirectToAction("Replies", new { post });
        }

        public ActionResult CreateTopic(string category)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTopic(string category, CreateTopicPageTopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                topicService.CreateTopic(new TopicEntity
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreationTime = DateTime.Now,
                    CreatorId = userService.GetUserByName(User.Identity.Name).Id,
                    CategoryId = categoryService.GetCategoryByName(category).Id
                });
            }
            return RedirectToAction("Categories");
        }

        public ActionResult CreatePost(string topic)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(string topic, CreatePostPagePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                postService.CreatePost(new PostEntity
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreationTime = DateTime.Now,
                    CreatorId = userService.GetUserByName(User.Identity.Name).Id,
                    TopicId = topicService.GetTopicByName(topic).Id
                });
            }
            return RedirectToAction("Posts", new { topic });
        }
    }
}