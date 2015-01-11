using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers
{
    public static class AdminPagesMapper
    {
        public static AdminPagesUserViewModel ToAdminPagesUserViewModel(UserEntity userEntity)
        {
            return new AdminPagesUserViewModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                DateOfBirth = userEntity.DateOfBirth,
                JoinDate = userEntity.JoinDate,
                LastActivity = userEntity.LastActivity,
                Location = userEntity.Location,
                IsOnline = userEntity.IsOnline
            };
        }
    }
}