using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryEntity> GetAllCategories();
        CategoryEntity GetCategoryById(int id);
        CategoryEntity GetCategoryByName(string name);
        void UpdateCategory(CategoryEntity category);
        void DeleteCategory(CategoryEntity category);
    }
}