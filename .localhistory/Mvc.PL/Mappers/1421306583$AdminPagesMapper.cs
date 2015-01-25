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
            throw new NotImplementedException();
        }

        public static AdminPagesPostViewModel ToAdminPagesPostViewModel(this PostEntity postEntity)
        {
            throw new NotImplementedException();
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