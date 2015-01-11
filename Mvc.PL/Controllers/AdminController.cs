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
        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View(userService.GetUsersInRole("Reader").Select(AdminPagesMapper.ToAdminPagesUserViewModel));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                userService.DeleteUser(new UserEntity { Id = id });

                TempData["message"] = "User deleted successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["message"] = "Cannot delete this user. Check if he has created any topics, posts or replies and delete them first";
                return RedirectToAction("Index");
            }
        }
    }
}