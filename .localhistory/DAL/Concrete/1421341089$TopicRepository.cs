using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DbContext context;

        public TopicRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalTopic> GetAll()
        {
            return context.Set<Topic>().Select(DalTopicMapper.ToDalTopic);
        }

        public DalTopic GetByName(string name)
        {
            return context.Set<Topic>()
                .Single(topic => topic.Name.ToLower() == name.ToLower())
                .ToDalTopic();
        }

        public void Create(DalTopic entity)
        {
            context.Set<Topic>().Add(entity.ToOrmTopic());
        }

        public void Update(DalTopic entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTopic entity)
        {
            context.Set<Topic>().Remove(context.Set<Topic>().Single(topic => topic.Id == entity.Id));
        }
    }
}