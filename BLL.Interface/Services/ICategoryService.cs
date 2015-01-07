using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryEntity> GetAllCategories();
    }
}