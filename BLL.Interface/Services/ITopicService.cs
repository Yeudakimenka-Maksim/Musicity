using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ITopicService
    {
        IEnumerable<TopicEntity> GetAllTopics();
        //IEnumerable<TopicEntity> GetByPredicate(Func<TopicEntity, bool> predicate);
    }
}