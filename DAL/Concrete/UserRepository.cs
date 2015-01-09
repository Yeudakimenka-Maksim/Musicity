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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(DalUserMapper.ToDalUser);
        }

        public DalUser GetByName(string name)
        {
            return context.Set<User>()
                .SingleOrDefault(user => user.Name.ToLower() == name.ToLower())
                .ToDalUser();
        }

        public void Create(DalUser entity)
        {
            context.Set<User>().Add(entity.ToOrmUser());
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