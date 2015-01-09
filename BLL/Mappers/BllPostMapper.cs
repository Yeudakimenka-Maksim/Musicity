using System;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllPostMapper
    {
        public static DalPost ToDalPost(this PostEntity postEntity)
        {
            throw new NotImplementedException();
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