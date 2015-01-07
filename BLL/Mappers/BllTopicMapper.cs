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
                CategoryId = topicEntity.CategoryId,
                Creator = topicEntity.Creator.ToDalUser(),
                Category = topicEntity.Category.ToDalCategory(),
                //Posts = (ICollection<DalPost>) topicEntity.Posts.Select(p => p.ToDalPost())
            };
        }

        public static TopicEntity ToBllTopic(this DalTopic dalTopic)
        {
            return new TopicEntity
            {
                Id = dalTopic.Id,
                Name = dalTopic.Name,
                Description = dalTopic.Description,
                CreationTime = dalTopic.CreationTime,
                CreatorId = dalTopic.CreatorId,
                CategoryId = dalTopic.CategoryId,
                Creator = dalTopic.Creator.ToBllUser(),
                Category = dalTopic.Category.ToBllCategory(),
                Posts = dalTopic.Posts.Select(p => p.ToBllPost()).ToList()
            };
        }
    }
}