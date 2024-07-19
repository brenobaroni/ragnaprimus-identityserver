using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts_Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<IList<TEntity>> BulkAddAsync(IList<TEntity> objs);
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        TEntity Update(TEntity obj);
        IList<TEntity> BulkUpdate(IList<TEntity> objs);
        void Remove(long id);
        void Remove(Guid id);
        void BulkRemove(IList<long> ids);
        void ClearTracked();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task DisposeAsync();
        Task<IDbContextTransaction> BeginTransaction();
        DbSet<TEntity> Database();
    }
}
