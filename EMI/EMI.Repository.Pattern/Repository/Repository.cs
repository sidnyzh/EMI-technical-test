using EMI.Repository.EFC;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EMI.Repository.Pattern.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Variables
        private readonly EmiDbContext _Context;
        private readonly DbSet<TEntity> _entities;
        #endregion

        #region Constructor
        public Repository(EmiDbContext Context)
        {
            _Context = Context;
            _entities = _Context.Set<TEntity>();
        }
        #endregion

 
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<TEntity> GetWithIncludesAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return await _entities.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? expression = null, int? top = null)
        {
            bool topBit = top is null;
            List<TEntity> result;
            if (expression is null)
            {
                if (topBit)
                {
                    result = await _entities.ToListAsync();
                }
                else
                {
                    result = await _entities.TakeLast((int)top!).ToListAsync();
                }

            }
            else
            {
                if (topBit)
                {
                    result = await _entities.Where(expression).ToListAsync();
                }
                else
                {
                    result = await _entities.Where(expression).TakeLast((int)top!).ToListAsync();
                }
            }

            return result;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken token = default)
        {
            return await _entities.AnyAsync(expression!, token);
        }
        
        public async Task<bool> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            int changes = await _Context.SaveChangesAsync();
            return changes > 0;
        }
       
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            int changes = await _Context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            _Context.Remove(entity);
            int changes = await _Context.SaveChangesAsync();

            return changes > 0;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            TEntity entity = await GetByIdAsync(id);
            _Context.Remove(entity);
            int changes = await _Context.SaveChangesAsync();
            return changes > 0;
        }
              
        public async Task<IEnumerable<TEntity>> ExecuteQueryAsync(string query)
        {
            return await _entities.FromSqlRaw(query).ToListAsync();
        }
    }
}
