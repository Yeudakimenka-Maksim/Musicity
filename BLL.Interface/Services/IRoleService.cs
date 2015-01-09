﻿using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAllRoles();
        RoleEntity GetRoleByName(string name);
    }
}