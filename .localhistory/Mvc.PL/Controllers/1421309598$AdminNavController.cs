using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.PL.Controllers
{
    public class AdminNavController : Controller
    {
        public PartialViewResult Menu(string table = null)
        {
            ViewBag.SelectedCategory = table;
            IEnumerable<string> categories = repository.Products
                .Select(product => product.Category)
                .Distinct()
                .OrderBy(c => c);
            return PartialView(categories);
        }
    }
}