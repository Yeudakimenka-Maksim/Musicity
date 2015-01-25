using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers.AdminPages
{
    public static class AdminPagesReplyMapper
    {
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
    }
}