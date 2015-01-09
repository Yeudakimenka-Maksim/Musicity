using System.Web.Mvc;

namespace Mvc.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}