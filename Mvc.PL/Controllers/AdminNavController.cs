using System.Web.Mvc;

namespace Mvc.PL.Controllers
{
    public class AdminNavController : Controller
    {
        public PartialViewResult Menu(string table = null)
        {
            ViewBag.SelectedTable = table;
            var links = new[] { "Categories", "Topics", "Posts", "Replies", "Users" };
            return PartialView(links);
        }
    }
}