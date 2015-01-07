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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext context;

        public CategoryRepository(IUnitOfWork uow)
        {
            context = uow.Context;
        }

        public IEnumerable<DalCategory> GetAll()
        {
            return context.Set<Category>().Select(DalCategoryMapper.ToDalCategory);
        }

        public void Create(DalCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}