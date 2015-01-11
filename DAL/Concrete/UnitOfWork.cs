using System;
using System.Data.Entity;
using DAL.Interface.Repositories;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; private set; }

        public void Commit()
        {
            if (Context != null)
                Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && Context != null)
                Context.Dispose();
        }
    }
}