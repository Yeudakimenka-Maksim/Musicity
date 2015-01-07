using System.Linq;
using BLL.Interface.Entities;
using Mvc.PL.ViewModels.CategoriesPage;

namespace Mvc.PL.Mappers
{
    public static class CategoriesPageMapper
    {
        public static CategoriesPageCategoryViewModel ToCategoriesPageCategoryViewModel(this CategoryEntity categoryEntity)
        {
            return new CategoriesPageCategoryViewModel
            {
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,
                Topics =
                    categoryEntity.Topics == null || !categoryEntity.Topics.Any()
                        ? null
                        : categoryEntity.Topics.Select(topic => new CategoriesPageTopicViewModel
                        {
                            Name = topic.Name,
                            Description = topic.Description,
                            PostCount = topic.Posts.Count,
                            LastPost = topic.Posts == null || !topic.Posts.Any()
                                ? null
                                : ToCategoriesPagePostViewModel(
                                    topic.Posts.Single(post => post.CreationTime == topic.Posts.Max(p => p.CreationTime)))
                        })
            };
        }

        private static CategoriesPagePostViewModel ToCategoriesPagePostViewModel(this PostEntity postEntity)
        {
            return new CategoriesPagePostViewModel
            {
                Name = postEntity.Name,
                Description = postEntity.Description,
                Creator = new CategoriesPageUserViewModel
                {
                    Name = postEntity.Creator.Name
                },
                CreationTime = postEntity.CreationTime
            };
        }
    }
}