using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ITopicService
    {
        IEnumerable<TopicEntity> GetAllTopics();
        TopicEntity GetTopicById(int id);
        TopicEntity GetTopicByName(string name);
        void CreateTopic(TopicEntity topic);
        void DeleteTopic(TopicEntity topic);
    }
}