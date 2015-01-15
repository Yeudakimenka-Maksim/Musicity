using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Mvc.PL.Mappers;

namespace Mvc.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly IReplyService replyService;
        private readonly ITopicService topicService;
        private readonly IUserService userService;

        public AdminController(ICategoryService categoryService, IPostService postService, IReplyService replyService,
            ITopicService topicService, IUserService userService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.replyService = replyService;
            this.topicService = topicService;
            this.userService = userService;
        }

        public ActionResult Categories()
        {
            return View(categoryService.GetAllCategories().Select(AdminPagesMapper.ToAdminPagesCategoryViewModel));
        }

        public ActionResult Topics()
        {
            return View(topicService.GetAllTopics().Select(AdminPagesMapper.ToAdminPagesTopicViewModel));
        }

        public ActionResult Posts()
        {
            return View(postService.GetAllPosts().Select(AdminPagesMapper.ToAdminPagesPostViewModel));
        }

        public ActionResult Replies()
        {
            return View(replyService.GetAllReplies().Select(AdminPagesMapper.ToAdminPagesReplyViewModel));
        }

        public ActionResult Users()
        {
            return View(userService.GetUsersInRole("Reader").Select(AdminPagesMapper.ToAdminPagesUserViewModel));
        }

        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                userService.DeleteUser(new UserEntity { Id = id });

                TempData["message"] = "User deleted successfully";
                return RedirectToAction("Users");
            }
            catch
            {
                TempData["message"] =
                    "Cannot delete this user. Check if he has created any topics, posts or replies and delete them first";
                return RedirectToAction("Users");
            }
        }
    }
}