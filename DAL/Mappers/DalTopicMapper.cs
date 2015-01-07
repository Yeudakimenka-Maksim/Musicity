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
                CategoryId = dalTopic.CategoryId,
                Creator = dalTopic.Creator.ToOrmUser(),
                Category = dalTopic.Category.ToOrmCategory(),
                Posts = dalTopic.Posts.Select(p => p.ToOrmPost()).ToList()
            };
        }

        public static DalTopic ToDalTopic(this Topic ormTopic)
        {
            return new DalTopic
            {
                Id = ormTopic.Id,
                Name = ormTopic.Name,
                Description = ormTopic.Description,
                CreationTime = ormTopic.CreationTime,
                CreatorId = ormTopic.CreatorId,
                CategoryId = ormTopic.CategoryId,
                Creator = ormTopic.Creator.ToDalUser(),
                Category = ormTopic.Category.ToDalCategory(),
                Posts = ormTopic.Posts.Select(p => p.ToDalPost()).ToList()
            };
        }
    }
}