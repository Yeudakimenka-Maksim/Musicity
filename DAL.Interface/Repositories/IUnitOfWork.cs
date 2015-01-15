using System;
using System.Data.Entity;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}