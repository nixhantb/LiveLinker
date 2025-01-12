
namespace LiveLinker.Events.LiveLinker.Events.Core.Interfaces{

    public interface IRepository<TEntity, TModel> 
    where TEntity: class
    where TModel: class
    {

        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync<TKey>(TKey id);
        Task<TModel> AddAsync(TEntity entity);
        Task<TModel> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync<TKey>(TKey id);

    }
}