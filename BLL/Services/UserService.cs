using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IRoleRepository roleRepository, IUnitOfWork uow, IUserRepository userRepository)
        {
            this.roleRepository = roleRepository;
            this.uow = uow;
            this.userRepository = userRepository;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            //using (uow)
            {
                return userRepository.GetAll().Select(user => user.ToBllUser());
            }
        }

        public UserEntity GetUserByName(string name)
        {
            //using (uow)
            {
                return userRepository.GetByName(name).ToBllUser();
            }
        }

        public IEnumerable<UserEntity> GetUsersInRole(string role)
        {
            return userRepository.GetAllInRole(role).Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            //using (uow)
            {
                userRepository.Create(user.ToDalUser());
                uow.Commit();
            }
        }

        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }
    }
}