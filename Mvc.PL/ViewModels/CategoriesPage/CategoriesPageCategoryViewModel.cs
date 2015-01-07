using System.Collections.Generic;

namespace Mvc.PL.ViewModels.CategoriesPage
{
    public class CategoriesPageCategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoriesPageTopicViewModel> Topics { get; set; }
    }
}