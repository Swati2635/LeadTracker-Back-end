using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : Identity
    {
        public readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<T>().AsNoTracking());

        }

        public async Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(_context.Set<T>().Where(expression).AsNoTracking());
        }

        public async Task CreateAsync(T entity)
        {
            entity.IsActive = true;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = false;

            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsActive = false;
            entity.IsDeleted = true;
            await UpdateAsync(entity);
            await _context.SaveChangesAsync();
        }

    }
}
