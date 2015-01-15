using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers.AdminPages
{
    public static class AdminPagesTopicMapper
    {
        public static AdminPagesTopicViewModel ToAdminPagesTopicViewModel(this TopicEntity topicEntity)
        {
            return new AdminPagesTopicViewModel
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                Description = topicEntity.Description,
                CreationTime = topicEntity.CreationTime,
                CreatorId = topicEntity.CreatorId,
                CategoryId = topicEntity.CategoryId,
                Creator = topicEntity.Creator.ToAdminPagesUserViewModel(),
                Category = new AdminPagesCategoryViewModel
                {
                    Id = topicEntity.Category.Id,
                    Name = topicEntity.Category.Name,
                    Description = topicEntity.Category.Description,
                    CreationTime = topicEntity.Category.CreationTime
                }
            };
        }

        public static TopicEntity ToBllTopic(this AdminPagesTopicViewModel topicViewModel)
        {
            return new TopicEntity
            {
                Id = topicViewModel.Id,
                Name = topicViewModel.Name,
                Description = topicViewModel.Description,
                CreationTime = topicViewModel.CreationTime,
                CreatorId = topicViewModel.CreatorId,
                CategoryId = topicViewModel.CategoryId
            };
        }
    }
}