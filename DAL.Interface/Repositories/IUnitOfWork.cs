using System;
using System.Data.Entity;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Open - Do all things - Commit or Rollback
        DbContext Context { get; }
        void Commit();
    }
}