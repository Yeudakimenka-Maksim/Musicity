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
            var x = context.Set<Post>();
            return context.Set<Post>().Select(DalPostMapper.ToDalPost);
        }

        public DalPost GetByName(string name)
        {
            return context.Set<Post>()
                .Single(post => post.Name.ToLower() == name.ToLower())
                .ToDalPost();
        }

        public void Create(DalPost entity)
        {
            context.Set<Post>().Add(entity.ToOrmPost());
        }

        public void Update(DalPost entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalPost entity)
        {
            context.Set<Post>().Remove(context.Set<Post>().Single(post => post.Id == entity.Id));
        }
    }
}