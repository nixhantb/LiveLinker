
namespace LiveLinker.Events.LiveLinker.Events.Core.Interfaces{

    public interface IRepository<TEntity, TModel> 
    where TEntity: class
    where TModel: class
    {

        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync<TKey>(TKey id);
        Task<TModel> AddRecordsAsync(TEntity entity);
        Task<TModel> UpdateRecordsAsync(TEntity entity);
        Task<bool> DeleteRecordsAsync<TKey>(TKey id);

    }
}