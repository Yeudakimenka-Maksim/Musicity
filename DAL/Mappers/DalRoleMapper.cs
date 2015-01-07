﻿using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalRoleMapper
    {
        public static Role ToOrmRole(this DalRole dalRole)
        {
            return new Role
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Description = dalRole.Description,
                Users = dalRole.Users.Select(u => u.ToOrmUser()).ToList()
            };
        }

        public static DalRole ToDalRole(this Role ormRole)
        {
            return new DalRole
            {
                Id = ormRole.Id,
                Name = ormRole.Name,
                Description = ormRole.Description,
                Users = ormRole.Users.Select(u => u.ToDalUser()).ToList()
            };
        }
    }
}