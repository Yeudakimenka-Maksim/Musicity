using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalTopicMapper
    {
        public static Topic ToOrmTopic(this DalTopic dalTopic)
        {
            return new Topic
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                Description = dalTopic.Description,
                CreationTime = dalTopic.CreationTime,
                CreatorId = dalTopic.CreatorId,
                CategoryId = dalTopic.CategoryId
            };
        }

        public static DalTopic ToDalTopic(this Topic ormTopic)
        {
            return new DalTopic
            {
                Id = ormTopic.Id,
                Name = ormTopic.Name,
                Description = ormTopic.Description,
                Posts = ormTopic.Posts.Select(post => new DalPost
                {
                    Id = post.Id,
                    Name = post.Name,
                    Description = post.Description,
                    CreationTime = post.CreationTime,
                    Creator = new DalUser
                    {
                        Id = post.Creator.Id,
                        Name = post.Creator.Name
                    },
                    Replies = post.Replies.Select(reply => new DalReply()).ToList()
                }).ToList()
            };
        }
    }
}