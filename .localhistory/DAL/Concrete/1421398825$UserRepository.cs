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

        public DalUser GetById(int id)
        {
            return context.Set<User>().Single(user => user.Id == id).ToDalUser();
        }

        public DalUser GetByName(string name)
        {
            return context.Set<User>()
                .SingleOrDefault(user => user.Name.ToLower() == name.ToLower())
                .ToDalUser();
        }

        public IEnumerable<DalUser> GetAllInRole(string role)
        {
            return context.Set<User>()
                .Where(user => user.Roles.Any(r => r.Name.ToLower() == role.ToLower()))
                .Select(DalUserMapper.ToDalUser);
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
            context.Set<User>().Remove(context.Set<User>().Single(user => user.Id == entity.Id));
        }
    }
}