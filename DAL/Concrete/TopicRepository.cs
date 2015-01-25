using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public TopicRepository(UnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalTopic> GetAll()
        {
            return context.Set<Topic>().Select(DalTopicMapper.ToDalTopic);
        }

        public DalTopic GetById(int id)
        {
            return context.Set<Topic>().Single(topic => topic.Id == id).ToDalTopic();
        }

        public DalTopic GetByName(string name)
        {
            return context.Set<Topic>()
                .SingleOrDefault(topic => topic.Name.ToLower() == name.ToLower())
                .ToDalTopic();
        }

        public void Create(DalTopic entity)
        {
            context.Set<Topic>().Add(entity.ToOrmTopic());
        }

        public void Update(DalTopic entity)
        {
            context.Set<Topic>().AddOrUpdate(topic => topic.Id, entity.ToOrmTopic());
        }

        public void Delete(DalTopic entity)
        {
            context.Set<Topic>().Remove(context.Set<Topic>().Single(topic => topic.Id == entity.Id));
        }
    }
}