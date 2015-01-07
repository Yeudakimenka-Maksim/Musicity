using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllPostMapper
    {
        public static DalPost ToDalPost(this PostEntity postEntity)
        {
            return new DalPost
            {
                Id = postEntity.Id,
                Name = postEntity.Name,
                Description = postEntity.Description,
                CreationTime = postEntity.CreationTime,
                CreatorId = postEntity.CreatorId,
                TopicId = postEntity.TopicId,
                Creator = postEntity.Creator.ToDalUser(),
                Topic = postEntity.Topic.ToDalTopic(),
                //Replies = (ICollection<DalReply>) postEntity.Replies.Select(r => r.ToDalReply())
            };
        }

        public static PostEntity ToBllPost(this DalPost dalPost)
        {
            return new PostEntity
            {
                Id = dalPost.Id,
                Name = dalPost.Name,
                Description = dalPost.Description,
                CreationTime = dalPost.CreationTime,
                CreatorId = dalPost.CreatorId,
                TopicId = dalPost.TopicId,
                Creator = dalPost.Creator.ToBllUser(),
                Topic = dalPost.Topic.ToBllTopic(),
                Replies = dalPost.Replies.Select(r => r.ToBllReply()).ToList()
            };
        }
    }
}