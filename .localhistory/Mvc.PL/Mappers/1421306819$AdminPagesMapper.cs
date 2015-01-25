using System;
using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers
{
    public static class AdminPagesMapper
    {
        public static AdminPagesCategoryViewModel ToAdminPagesCategoryViewModel(this CategoryEntity categoryEntity)
        {
            return new AdminPagesCategoryViewModel
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,
                CreationTime = categoryEntity.CreationTime,
                Creator = categoryEntity.Creator.ToAdminPagesUserViewModel()
            };
        }

        public static AdminPagesTopicViewModel ToAdminPagesTopicViewModel(this TopicEntity topicEntity)
        {
            return new AdminPagesTopicViewModel
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                Description = topicEntity.Description,
                CreationTime = topicEntity.CreationTime,
                Creator = topicEntity.Creator.ToAdminPagesUserViewModel(),
                Category = new AdminPagesCategoryViewModel
                {
                    Id = topicEntity.Category.Id,
                    Name = topicEntity.Category.Name,
                    Description = topicEntity.Category.Description,
                    CreationTime = topicEntity.Category.CreationTime,
                }
            };
        }

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

        public static AdminPagesReplyViewModel ToAdminPagesReplyViewModel(this ReplyEntity replyEntity)
        {
            throw new NotImplementedException();
        }

        public static AdminPagesUserViewModel ToAdminPagesUserViewModel(this UserEntity userEntity)
        {
            return new AdminPagesUserViewModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                DateOfBirth = userEntity.DateOfBirth,
                JoinDate = userEntity.JoinDate,
                LastActivity = userEntity.LastActivity,
                Location = userEntity.Location,
                IsOnline = userEntity.IsOnline
            };
        }
    }
}