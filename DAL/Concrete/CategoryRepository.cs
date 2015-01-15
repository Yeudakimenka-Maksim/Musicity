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

        public DalCategory GetById(int id)
        {
            return context.Set<Category>().Single(category => category.Id == id).ToDalCategory();
        }

        public DalCategory GetByName(string name)
        {
            return context.Set<Category>()
                .Single(category => category.Name.ToLower() == name.ToLower())
                .ToDalCategory();
        }

        public void Create(DalCategory entity)
        {
            context.Set<Category>().Add(entity.ToOrmCategory());
        }

        public void Update(DalCategory entity)
        {
            context.Set<Category>().AddOrUpdate(category => category.Id, entity.ToOrmCategory());
        }

        public void Delete(DalCategory entity)
        {
            context.Set<Category>().Remove(context.Set<Category>().Single(category => category.Id == entity.Id));
        }
    }
}