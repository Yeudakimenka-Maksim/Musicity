using System.Linq;
using BLL.Interface.Entities;
using Mvc.PL.ViewModels.TopicPage;

namespace Mvc.PL.Mappers
{
    public static class TopicPageMapper
    {
        public static TopicPageTopicViewModel ToTopicPageTopicViewModel(this TopicEntity topicEntity)
        {
            return new TopicPageTopicViewModel
            {
                Name = topicEntity.Name,
                Description = topicEntity.Description,
                PostCount =
                    topicEntity.Posts == null || !topicEntity.Posts.Any() ? 0 : topicEntity.Posts.Count,
                Posts = topicEntity.Posts == null || !topicEntity.Posts.Any()
                    ? null
                    : topicEntity.Posts.Select(post => new TopicPagePostViewModel
                    {
                        Name = post.Name,
                        Description = post.Description,
                        CreationTime = post.CreationTime,
                        Creator = new TopicPageUserViewModel
                        {
                            Name = post.Creator.Name
                        },
                        ReplyCount = post.Replies == null || !post.Replies.Any() ? 0 : post.Replies.Count
                    })
            };
        }
    }
}