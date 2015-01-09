using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork uow;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork uow)
        {
            this.uow = uow;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryEntity> GetAllCategories()
        {
            using (uow)
            {
                return categoryRepository.GetAll().Select(BllCategoryMapper.ToBllCategory);
            }
        }
    }
}