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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(DalRoleMapper.ToDalRole);
        }

        public DalRole GetByName(string name)
        {
            return context.Set<Role>()
                .Single(role => role.Name.ToLower() == name.ToLower())
                .ToDalRole();
        }

        public void Create(DalRole entity)
        {
            context.Set<Role>().Add(entity.ToOrmRole());
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}