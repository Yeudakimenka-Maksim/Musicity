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
                TopicId = postEntity.TopicId
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
                Creator = new UserEntity
                {
                    Id = dalPost.Creator.Id,
                    Name = dalPost.Creator.Name,
                    DateOfBirth = dalPost.Creator.DateOfBirth,
                    JoinDate = dalPost.Creator.JoinDate,
                    LastActivity = dalPost.Creator.LastActivity,
                    Location = dalPost.Creator.Location,
                    IsOnline = dalPost.Creator.IsOnline
                },
                Topic = new TopicEntity
                {
                    Id = dalPost.Topic.Id,
                    Name = dalPost.Topic.Name,
                    Description = dalPost.Topic.Description,
                    CreationTime = dalPost.Topic.CreationTime,
                },
                Replies = dalPost.Replies.Select(reply => new ReplyEntity
                {
                    Id = reply.Id,
                    WrittenTime = reply.WrittenTime,
                    Content = reply.Content,
                    Writer = new UserEntity
                    {
                        Name = reply.Writer.Name,
                        JoinDate = reply.Writer.JoinDate,
                        Location = reply.Writer.Location,
                        IsOnline = reply.Writer.IsOnline,
                        Posts = reply.Writer.Posts.Select(post => new PostEntity()).ToList(),
                        Roles = reply.Writer.Roles.Select(role => new RoleEntity
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