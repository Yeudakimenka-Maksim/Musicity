using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUsers();
        UserEntity GetUserByName(string name);
        IEnumerable<UserEntity> GetUsersInRole(string role);
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}