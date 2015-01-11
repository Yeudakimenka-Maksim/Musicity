using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Password = dalUser.Password,
                DateOfBirth = dalUser.DateOfBirth,
                JoinDate = dalUser.JoinDate,
                LastActivity = dalUser.LastActivity,
                Location = dalUser.Location,
                IsOnline = dalUser.IsOnline,
                Roles = dalUser.Roles == null
                    ? null
                    : dalUser.Roles.Select(role => new Role
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }).ToList()
            };
        }

        public static DalUser ToDalUser(this User ormUser)
        {
            return ormUser == null
                ? null
                : new DalUser
                {
                    Id = ormUser.Id,
                    Name = ormUser.Name,
                    Password = ormUser.Password,
                    DateOfBirth = ormUser.DateOfBirth,
                    JoinDate = ormUser.JoinDate,
                    LastActivity = ormUser.LastActivity,
                    Location = ormUser.Location,
                    IsOnline = ormUser.IsOnline,
                    Roles = ormUser.Roles.Select(role => new DalRole
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }).ToList()
                };
        }
    }
}