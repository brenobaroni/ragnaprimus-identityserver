using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts_Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repository
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : class where TContext : DbContext, IDisposable
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            //Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            return obj;
        }

        public virtual async Task<IList<TEntity>> BulkAddAsync(IList<TEntity> objs)
        {
            await DbSet.AddRangeAsync(objs);
            return objs;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public virtual IList<TEntity> BulkUpdate(IList<TEntity> objs)
        {
            DbSet.UpdateRange(objs);
            return objs;
        }

        public virtual void Remove(long id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void BulkRemove(IList<long> ids)
        {
            DbSet.RemoveRange(DbSet.Find(ids));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
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

        public async Task DisposeAsync()
        {
            await Db.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public virtual DbSet<TEntity> Database()
        {
            return DbSet;
        }

        public virtual void ClearTracked() => Db.ChangeTracker.Clear();

        public async Task<IDbContextTransaction> BeginTransaction() => await Db.Database.BeginTransactionAsync();
    }
}
