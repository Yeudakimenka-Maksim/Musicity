using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        IEnumerable<DalUser> GetAllInRole(string role);
    }
}