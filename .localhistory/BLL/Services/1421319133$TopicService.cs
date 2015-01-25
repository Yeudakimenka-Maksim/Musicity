using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository topicRepository;
        private readonly IUnitOfWork uow;

        public TopicService(ITopicRepository topicRepository, IUnitOfWork uow)
        {
            this.uow = uow;
            this.topicRepository = topicRepository;
        }

        public IEnumerable<TopicEntity> GetAllTopics()
        {
            //using (uow)
            {
                return topicRepository.GetAll().Select(topic => new TopicEntity
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Description = topic.Description,
                    CreationTime = topic.CreationTime,
                    Creator = new UserEntity
                    {
                        Id = topic.Creator.Id,
                        Name = topic.Creator.Name,
                        DateOfBirth = topic.Creator.DateOfBirth,
                        JoinDate = topic.Creator.JoinDate,
                        LastActivity = topic.Creator.LastActivity,
                        Location = topic.Creator.Location,
                        IsOnline = topic.Creator.IsOnline
                    },
                    Category = new CategoryEntity
                    {
                        Id = topic.Category.Id,
                        Name = topic.Category.Name,
                        Description = topic.Category.Description,
                        CreationTime = topic.Category.CreationTime
                    },
                    Posts = topic.Posts.Select(post => new PostEntity
                    {
                        Id = post.Id,
                        Name = post.Name,
                        Description = post.Description,
                        CreationTime = post.CreationTime,
                        Creator = new UserEntity
                        {
                            Name = post.Creator.Name
                        },
                        Replies = post.Replies.Select(reply => new ReplyEntity()).ToList()
                    }).ToList()
                });
            }
        }

        public TopicEntity GetTopicByName(string name)
        {
            //using (uow)
            {
                return topicRepository.GetByName(name).ToBllTopic();
            }
        }

        public void CreateTopic(TopicEntity topic)
        {
            topicRepository.Create(topic.ToDalTopic());
            uow.Commit();
        }
    }
}