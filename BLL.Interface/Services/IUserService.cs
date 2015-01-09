using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUsers();
        UserEntity GetUserByName(string name);
        void CreateUser(UserEntity user);
    }
}