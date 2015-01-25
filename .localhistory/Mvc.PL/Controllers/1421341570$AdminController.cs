using System;
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

        public ActionResult EditCategory(int id)
        {
            return View(categoryService.GetCategoryById(id).ToAdminPagesCategoryViewModel());
        }

        public ActionResult UpdateCategory(int id)
        {
            throw new NotImplementedException();
        }

        #region Delete Actions

        [HttpPost]
        public ActionResult DeleteCategory(int id, FormCollection collection)
        {
            try
            {
                categoryService.DeleteCategory(new CategoryEntity { Id = id });
                TempData["message"] = "Category deleted successfully";
                return RedirectToAction("Categories");
            }
            catch
            {
                TempData["message"] =
                    "Cannot delete this category. Check if it contains any topics and delete them first";
                return RedirectToAction("Categories");
            }
        }

        [HttpPost]
        public ActionResult DeleteTopic(int id, FormCollection collection)
        {
            try
            {
                topicService.DeleteTopic(new TopicEntity { Id = id });
                TempData["message"] = "Topic deleted successfully";
                return RedirectToAction("Topics");
            }
            catch
            {
                TempData["message"] = "Cannot delete this topic. Check if it contains any posts and delete them first";
                return RedirectToAction("Topics");
            }
        }

        [HttpPost]
        public ActionResult DeletePost(int id, FormCollection collection)
        {
            try
            {
                postService.DeletePost(new PostEntity { Id = id });
                TempData["message"] = "Post deleted successfully";
                return RedirectToAction("Posts");
            }
            catch
            {
                TempData["message"] = "Cannot delete this post. Check if it contains any replies and delete them first";
                return RedirectToAction("Posts");
            }
        }

        [HttpPost]
        public ActionResult DeleteReply(int id, FormCollection collection)
        {
            try
            {
                replyService.DeleteReply(new ReplyEntity { Id = id });
                TempData["message"] = "Reply deleted successfully";
                return RedirectToAction("Replies");
            }
            catch
            {
                TempData["message"] = "Cannot delete this reply";
                return RedirectToAction("Replies");
            }
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

        #endregion
    }
}