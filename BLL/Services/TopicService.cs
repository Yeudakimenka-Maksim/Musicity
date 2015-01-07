using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
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
            using (uow)
            {
                return topicRepository.GetAll().Select(topic => new TopicEntity
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
                            Name = post.Creator.Name
                        },
                        Replies = post.Replies.Select(reply => new ReplyEntity()).ToList()
                    }).ToList()
                });
            }
        }
    }
}