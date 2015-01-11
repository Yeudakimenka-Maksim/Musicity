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
    public class ReplyRepository : IReplyRepository
    {
        private readonly DbContext context;

        public ReplyRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalReply> GetAll()
        {
            return context.Set<Reply>().Select(DalReplyMapper.ToDalReply);
        }

        public DalReply GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Create(DalReply entity)
        {
            context.Set<Reply>().Add(entity.ToOrmReply());
        }

        public void Update(DalReply entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalReply entity)
        {
            throw new NotImplementedException();
        }
    }
}