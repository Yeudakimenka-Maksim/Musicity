using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers.AdminPages
{
    public static class AdminPagesPostMapper
    {
        public static AdminPagesPostViewModel ToAdminPagesPostViewModel(this PostEntity postEntity)
        {
            return new AdminPagesPostViewModel
            {
                Id = postEntity.Id,
                Name = postEntity.Name,
                Description = postEntity.Description,
                CreationTime = postEntity.CreationTime,
                Creator = postEntity.Creator.ToAdminPagesUserViewModel(),
                Topic = new AdminPagesTopicViewModel
                {
                    Id = postEntity.Topic.Id,
                    Name = postEntity.Topic.Name,
                    Description = postEntity.Topic.Description,
                    CreationTime = postEntity.Topic.CreationTime,
                }
            };
        }
    }
}