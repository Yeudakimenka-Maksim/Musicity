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
    public class PostRepository : IPostRepository
    {
        private readonly DbContext context;

        public PostRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalPost> GetAll()
        {
            return context.Set<Post>().Select(DalPostMapper.ToDalPost);
        }

        public void Create(DalPost entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalPost entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalPost entity)
        {
            throw new NotImplementedException();
        }
    }
}