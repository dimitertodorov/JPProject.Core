using JPProject.Admin.Infra.Data.Context;
using JPProject.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JPProject.Admin.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly JPProjectAdminUIContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(JPProjectAdminUIContext adminUiContext)
        {
            Db = adminUiContext;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById<T>(T id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove<T>(T id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
