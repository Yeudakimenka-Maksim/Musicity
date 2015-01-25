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

        public static CategoryEntity ToBllCategory(this AdminPagesCategoryViewModel categoryViewModel)
        {
            return new CategoryEntity
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                CreationTime = categoryViewModel.CreationTime
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
            return new AdminPagesReplyViewModel
            {
                Id = replyEntity.Id,
                WrittenTime = replyEntity.WrittenTime,
                IsSubject = replyEntity.IsSubject,
                Content = replyEntity.Content,
                Post = new AdminPagesPostViewModel
                {
                    Id = replyEntity.Post.Id,
                    Name = replyEntity.Post.Name,
                    Description = replyEntity.Post.Description,
                    CreationTime = replyEntity.Post.CreationTime,
                },
                Writer = replyEntity.Writer.ToAdminPagesUserViewModel()
            };
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

        public static UserEntity ToBllUser(this AdminPagesUserViewModel userViewModel)
        {
            return new UserEntity
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                DateOfBirth = userViewModel.DateOfBirth,
                JoinDate = userViewModel.JoinDate,
                LastActivity = userViewModel.LastActivity,
                Location = userViewModel.Location,
                IsOnline = userViewModel.IsOnline
            };
        }
    }
}