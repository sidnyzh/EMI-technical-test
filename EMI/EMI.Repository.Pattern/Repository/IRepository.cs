using System.Linq.Expressions;

namespace EMI.Repository.Pattern.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        #region Async methods

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> GetWithIncludesAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? expression = null, int? top = null);
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);   
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(string id);  
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken token = default);    
        Task<IEnumerable<TEntity>> ExecuteQueryAsync(string query);
        #endregion

    }
}
