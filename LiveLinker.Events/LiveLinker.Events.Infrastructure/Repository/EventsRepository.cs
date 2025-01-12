using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Data;
using LiveLinker.Events.LiveLinker.Events.Mapper;
using LiveLinker.Events.LiveLinker.Events.Service.Models;

namespace LiveLinker.Events.LiveLinker.Events.Infrastructure.Repository{

    public class EventsRepository : IEventRepository
    {
        private readonly BaseDbContext _dbContext;

        public EventsRepository(BaseDbContext dbContext){
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<EventModel> AddRecordsAsync(Event entity)
        {
             try{
                var records = EventsMapper.ToDB(entity);

                _dbContext.Events.Add(records);
               
                await _dbContext.SaveChangesAsync();

                var responseModel = EventsMapper.ToModel(records);

                return responseModel;
            }
            catch(Exception ex){
                throw new Exception("Something went wrong", ex);
            }
        }

        public Task<bool> DeleteRecordsAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EventModel> GetByIdAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<EventModel> UpdateRecordsAsync(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}