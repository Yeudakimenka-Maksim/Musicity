using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using Mvc.PL.ViewModels.Other;

namespace Mvc.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;

        public HomeController(IUserService service)
        {
            this.service = service;
        }

        public ViewResult Index()
        {
            var temp = service.GetAllBllUsers();
            return View(service.GetAllBllUsers().Select(user => new UserViewModel { Name = user.Name }));
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Create(RegistrationViewModel user)
        {
            //var bllUser = new UserEntity { Name = user.UserName, RoleId = (int) user.Role };
            //service.CreateBllUser(bllUser);
            return RedirectToAction("Index");
        }
    }
}