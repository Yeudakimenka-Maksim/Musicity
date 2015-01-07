using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser { Id = user.Id, Name = user.Name });
        }

        //public DalUser GetById(int id)
        //{
        //    var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == id);
        //    return new DalUser { Id = ormUser.Id, Name = ormUser.Name };
        //}

        //public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public void Create(DalUser entity)
        {
            var ormUser = new User { Name = entity.Name, /*RoleId = dalUser.RoleId*/ };
            context.Set<User>().Add(ormUser);
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}