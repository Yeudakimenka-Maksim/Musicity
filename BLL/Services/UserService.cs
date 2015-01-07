using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork uow)
        {
            this.uow = uow;
            this.userRepository = userRepository;
        }

        public IEnumerable<UserEntity> GetAllBllUsers()
        {
            //using (uow)
            {
                return userRepository.GetAll().Select(user => user.ToBllUser());
            }
        }

        public void CreateBllUser(UserEntity user)
        {
            //using (uow)
            {
                userRepository.Create(user.ToDalUser());
                uow.Commit();
            }
        }
    }
}