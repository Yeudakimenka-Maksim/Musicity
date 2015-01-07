using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalPostMapper
    {
        public static Post ToOrmPost(this DalPost dalPost)
        {
            return new Post
            {
                Id = dalPost.Id,
                Name = dalPost.Name,
                Description = dalPost.Description,
                CreationTime = dalPost.CreationTime,
                CreatorId = dalPost.CreatorId,
                TopicId = dalPost.TopicId,
                Creator = dalPost.Creator.ToOrmUser(),
                Topic = dalPost.Topic.ToOrmTopic(),
                Replies = dalPost.Replies.Select(r => r.ToOrmReply()).ToList()
            };
        }

        public static DalPost ToDalPost(this Post ormPost)
        {
            return new DalPost
            {
                Id = ormPost.Id,
                Name = ormPost.Name,
                Description = ormPost.Description,
                CreationTime = ormPost.CreationTime,
                CreatorId = ormPost.CreatorId,
                TopicId = ormPost.TopicId,
                Creator = ormPost.Creator.ToDalUser(),
                Topic = ormPost.Topic.ToDalTopic(),
                Replies = ormPost.Replies.Select(r => r.ToDalReply()).ToList()
            };
        }
    }
}