﻿using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Mvc.PL.Mappers.AdminPages;
using Mvc.PL.ViewModels.AdminPages;

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
            return
                View(categoryService.GetAllCategories().Select(AdminPagesCategoryMapper.ToAdminPagesCategoryViewModel));
        }

        public ActionResult Topics()
        {
            return View(topicService.GetAllTopics().Select(AdminPagesTopicMapper.ToAdminPagesTopicViewModel));
        }

        public ActionResult Posts()
        {
            return View(postService.GetAllPosts().Select(AdminPagesPostMapper.ToAdminPagesPostViewModel));
        }

        public ActionResult Replies()
        {
            return View(replyService.GetAllReplies().Select(AdminPagesReplyMapper.ToAdminPagesReplyViewModel));
        }

        public ActionResult Users()
        {
            return View(userService.GetUsersInRole("Reader").Select(AdminPagesUserMapper.ToAdminPagesUserViewModel));
        }

        public ActionResult EditCategory(int id)
        {
            return View(categoryService.GetCategoryById(id).ToAdminPagesCategoryViewModel());
        }

        [HttpPost]
        public ActionResult EditCategory(AdminPagesCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                categoryService.UpdateCategory(model.ToBllCategory());
                return RedirectToAction("Categories", "Admin");
            }
            return View(model);
        }

        public ActionResult EditTopic(int id)
        {
            return View(topicService.GetTopicById(id).ToAdminPagesTopicViewModel());
        }

        [HttpPost]
        public ActionResult EditTopic(AdminPagesTopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                topicService.UpdateTopic(model.ToBllTopic());
                return RedirectToAction("Topics", "Admin");
            }
            return View(model);
        }

        public ActionResult EditPost(int id)
        {
            return View(postService.GetPostById(id).ToAdminPagesPostViewModel());
        }

        [HttpPost]
        public ActionResult EditPost(AdminPagesPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                postService.UpdatePost(model.ToBllPost());
                return RedirectToAction("Posts", "Admin");
            }
            return View(model);
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