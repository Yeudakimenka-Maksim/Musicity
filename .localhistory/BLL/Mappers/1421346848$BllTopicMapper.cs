using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllTopicMapper
    {
        public static DalTopic ToDalTopic(this TopicEntity topicEntity)
        {
            return new DalTopic
            {
                Id = topicEntity.Id,
                Name = topicEntity.Name,
                Description = topicEntity.Description,
                CreationTime = topicEntity.CreationTime,
                CreatorId = topicEntity.CreatorId,
                CategoryId = topicEntity.CategoryId
            };
        }

        public static TopicEntity ToBllTopic(this DalTopic dalTopic)
        {
            return new TopicEntity
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                Description = dalTopic.Description,
                Posts = dalTopic.Posts.Select(post => new PostEntity
                {
                    Id = post.Id,
                    Name = post.Name,
                    Description = post.Description,
                    CreationTime = post.CreationTime,
                    Creator = new UserEntity
                    {
                        Id = post.Creator.Id,
                        Name = post.Creator.Name
                    },
                    Replies = post.Replies.Select(reply => new ReplyEntity()).ToList()
                }).ToList()
            };
        }
    }
}