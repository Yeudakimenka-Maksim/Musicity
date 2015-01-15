using BLL.Interface.Entities;
using Mvc.PL.ViewModels.AdminPages;

namespace Mvc.PL.Mappers.AdminPages
{
    public static class AdminPagesUserMapper
    {
        public static AdminPagesUserViewModel ToAdminPagesUserViewModel(this UserEntity userEntity)
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

        public static UserEntity ToBllUser(this AdminPagesUserViewModel userViewModel)
        {
            return new UserEntity
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                DateOfBirth = userViewModel.DateOfBirth,
                JoinDate = userViewModel.JoinDate,
                LastActivity = userViewModel.LastActivity,
                Location = userViewModel.Location,
                IsOnline = userViewModel.IsOnline
            };
        }
    }
}