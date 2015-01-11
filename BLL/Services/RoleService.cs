using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork uow;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork uow)
        {
            this.roleRepository = roleRepository;
            this.uow = uow;
        }

        public IEnumerable<RoleEntity> GetAllRoles()
        {
            //using (uow)
            {
                return roleRepository.GetAll().Select(role => role.ToBllRole());
            }
        }

        public RoleEntity GetRoleByName(string name)
        {
            //using (uow)
            {
                return roleRepository.GetByName(name).ToBllRole();
            }
        }
    }
}