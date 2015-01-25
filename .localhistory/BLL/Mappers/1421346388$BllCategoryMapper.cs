using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllCategoryMapper
    {
        public static DalCategory ToDalCategory(this CategoryEntity categoryEntity)
        {
            return new DalCategory
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,
                CreationTime = categoryEntity.CreationTime
                //Topics = categoryEntity.Topics.Select(topic => new DalTopic
                //{
                //    Id = topic.Id,
                //    Name = topic.Name,
                //    Description = topic.Description,
                //    Posts = topic.Posts.Select(post => new DalPost
                //    {
                //        Id = post.Id,
                //        Name = post.Name,
                //        Description = post.Description,
                //        CreationTime = post.CreationTime,
                //        Creator = new DalUser
                //        {
                //            Id = post.Creator.Id,
                //            Name = post.Creator.Name
                //        }
                //    }).ToList()
                //}).ToList()
            };
        }

        public static CategoryEntity ToBllCategory(this DalCategory dalCategory)
        {
            return new CategoryEntity
            {
                Id = dalCategory.Id,
                Name = dalCategory.Name,
                Description = dalCategory.Description,
                CreationTime = dalCategory.CreationTime,
                Creator = new UserEntity
                {
                    Id = dalCategory.Creator.Id,
                    Name = dalCategory.Creator.Name,
                    Password = dalCategory.Creator.Password,
                    DateOfBirth = dalCategory.Creator.DateOfBirth,
                    JoinDate = dalCategory.Creator.JoinDate,
                    LastActivity = dalCategory.Creator.LastActivity,
                    Location = dalCategory.Creator.Location,
                    IsOnline = dalCategory.Creator.IsOnline
                },
                Topics = dalCategory.Topics.Select(topic => new TopicEntity
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Description = topic.Description,
                    Posts = topic.Posts.Select(post => new PostEntity
                    {
                        Id = post.Id,
                        Name = post.Name,
                        Description = post.Description,
                        CreationTime = post.CreationTime,
                        Creator = new UserEntity
                        {
                            Id = post.Creator.Id,
                            Name = post.Creator.Name
                        }
                    }).ToList()
                }).ToList()
            };
        }
    }
}