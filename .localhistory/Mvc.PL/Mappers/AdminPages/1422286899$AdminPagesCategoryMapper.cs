using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers.AdminPages
{
    public static class AdminPagesCategoryMapper
    {
        public static AdminPagesCategoryViewModel ToAdminPagesCategoryViewModel(this CategoryEntity categoryEntity)
        {
            return new AdminPagesCategoryViewModel
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,
                CreationTime = categoryEntity.CreationTime,
                CreatorId = categoryEntity.CreatorId,
                Creator = categoryEntity.Creator.ToAdminPagesUserViewModel()
            };
        }

        public static CategoryEntity ToBllCategory(this AdminPagesCategoryViewModel categoryViewModel)
        {
            return new CategoryEntity
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                CreationTime = categoryViewModel.CreationTime.ToUniversalTime(),
                CreatorId = categoryViewModel.CreatorId
            };
        }
    }
}