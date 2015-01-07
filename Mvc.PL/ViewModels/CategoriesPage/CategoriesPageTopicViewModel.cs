namespace Mvc.PL.ViewModels.CategoriesPage
{
    public class CategoriesPageTopicViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCount { get; set; }
        public CategoriesPagePostViewModel LastPost { get; set; }
    }
}
