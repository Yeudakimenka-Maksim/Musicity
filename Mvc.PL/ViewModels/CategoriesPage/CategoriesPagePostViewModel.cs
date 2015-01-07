using System;

namespace Mvc.PL.ViewModels.CategoriesPage
{
    public class CategoriesPagePostViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoriesPageUserViewModel Creator { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
