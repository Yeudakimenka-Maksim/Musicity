using System.Linq;
using BLL.Interface.Entities;
using Mvc.PL.ViewModels.PostPage;

namespace Mvc.PL.Mappers.UserPages
{
    public static class PostPageMapper
    {
        public static PostPagePostViewModel ToPostPagePostViewModel(this PostEntity postEntity)
        {
            return new PostPagePostViewModel
            {
                Name = postEntity.Name,
                Description = postEntity.Description,
                Replies = postEntity.Replies.Select(reply => new PostPageReplyViewModel
                {
                    WrittenTime = reply.WrittenTime,
                    Content = reply.Content,
                    Writer = new PostPageUserViewModel
                    {
                        Name = reply.Writer.Name,
                        JoinDate = reply.Writer.JoinDate,
                        Location = reply.Writer.Location,
                        IsOnline = reply.Writer.IsOnline,
                        Posts = reply.Writer.Posts.Select(post => new PostPagePostViewModel()).ToList(),
                        Roles = reply.Writer.Roles.Select(role => new PostPageRoleViewModel
                        {
                            Name = role.Name
                        }).ToList()
                    }
                }).ToList()
            };
        }
    }
}