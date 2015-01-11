using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Password = userEntity.Password,
                DateOfBirth = userEntity.DateOfBirth,
                JoinDate = userEntity.JoinDate,
                LastActivity = userEntity.LastActivity,
                Location = userEntity.Location,
                IsOnline = userEntity.IsOnline,
                Roles = userEntity.Roles == null
                    ? null
                    : userEntity.Roles.Select(role => new DalRole
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }).ToList()
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return dalUser == null
                ? null
                : new UserEntity
                {
                    Id = dalUser.Id,
                    Name = dalUser.Name,
                    Password = dalUser.Password,
                    DateOfBirth = dalUser.DateOfBirth,
                    JoinDate = dalUser.JoinDate,
                    LastActivity = dalUser.LastActivity,
                    Location = dalUser.Location,
                    IsOnline = dalUser.IsOnline,
                    Roles = dalUser.Roles.Select(role => new RoleEntity
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }).ToList()
                };
        }
    }
}