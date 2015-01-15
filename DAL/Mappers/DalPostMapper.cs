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
                TopicId = dalPost.TopicId
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
                Creator = new DalUser
                {
                    Id = ormPost.Creator.Id,
                    Name = ormPost.Creator.Name,
                    DateOfBirth = ormPost.Creator.DateOfBirth,
                    JoinDate = ormPost.Creator.JoinDate,
                    LastActivity = ormPost.Creator.LastActivity,
                    Location = ormPost.Creator.Location,
                    IsOnline = ormPost.Creator.IsOnline
                },
                Topic = new DalTopic
                {
                    Id = ormPost.Topic.Id,
                    Name = ormPost.Topic.Name,
                    Description = ormPost.Topic.Description,
                    CreationTime = ormPost.Topic.CreationTime,
                },
                Replies = ormPost.Replies.Select(reply => new DalReply
                {
                    Id = reply.Id,
                    WrittenTime = reply.WrittenTime,
                    Content = reply.Content,
                    Writer = new DalUser
                    {
                        Name = reply.Writer.Name,
                        JoinDate = reply.Writer.JoinDate,
                        Location = reply.Writer.Location,
                        IsOnline = reply.Writer.IsOnline,
                        Posts = reply.Writer.Posts.Select(post => new DalPost()).ToList(),
                        Roles = reply.Writer.Roles.Select(role => new DalRole
                        {
                            Id = role.Id,
                            Name = role.Name
                        }).ToList()
                    }
                }).ToList()
            };
        }
    }
}